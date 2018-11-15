using System;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;
using System.Linq;
using TrackingFood.Core.Domain.ViewModel;

namespace TrackingFood.Core.Application
{
    public class QueueApplication : BaseApplication, IQueueApplication
    {
        private readonly IQueueRepository _queueRepository;
        private readonly IQueueHistoryRepository _queueHistoryRepository;
        private readonly IDeliverymanRepository _deliverymanRepository;
        private readonly ICompanyBranchRepository _companyBranchRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderRepository _orderRepository;
        public QueueApplication(IUnitOfWork unitOfWork, IQueueRepository queueRepository, IQueueHistoryRepository queueHistoryRepository,
            IDeliverymanRepository deliverymanRepository, ICompanyBranchRepository companyBranchRepository, IAddressRepository addressRepository,
            IOrderRepository orderRepository) : base(unitOfWork)
        {
            _queueRepository = queueRepository;
            _queueHistoryRepository = queueHistoryRepository;
            _deliverymanRepository = deliverymanRepository;
            _companyBranchRepository = companyBranchRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
        }

        public int? Create(CreateOrderViewModel order)
        {
            var objOrder = new Order(order.Items.Select(p => new OrderItem(p.IdMenuItem, p.Amount)).ToList(),
                order.DeliveryValue, order.IdCompanyBranch, order.IdCustomer);

            if (IsError())
                return null;

            //distance
            var objCompanyBranchAddress = _addressRepository.GetCompanyBranchDapper(order.IdCompanyBranch);
            if (objCompanyBranchAddress == null)
            {
                AddError("Company branch address not found");
                return null;
            }
            var objDeliveryAddress = _addressRepository.GetDelivereyAddressDapper(order.IdDeliveryAddress);
            if (objDeliveryAddress == null)
            {
                AddError("Delivery address not found");
                return null;
            }

            var objQueue = new Queue(order.IdDeliveryAddress, objOrder, objOrder.IdCompanyBranch, objCompanyBranchAddress.CalculateDistence(objDeliveryAddress.Latitude, objDeliveryAddress.Longitude));
            
            _queueRepository.Create(objQueue);
            if (Commit())
                return objQueue.IdQueue;
            return null;
        }

        public void DeliverOrder(int idQueue)
        {
            var objQueue = _queueRepository.Get(idQueue, new string[]{ "Order" });
            if(objQueue == null)
            {
                AddError("Queue not found");
                return;
            }
            var objQueueHistory = new QueueHistory(objQueue);
            _queueHistoryRepository.Create(objQueueHistory);
            _queueRepository.Delete(objQueue);
            Commit();
        }

        public void Forward(ForwardToDeDeliveryman forwardToDeDeliveryman)
        {
            if (forwardToDeDeliveryman.Items.GroupBy(p => p.Position).Select(p => p.Count()).Any(p => p > 1))
            {
                AddError("Duplicate position");
                return;
            }

            var objDeliveyman = _deliverymanRepository.Get(forwardToDeDeliveryman.IdDeliveryman);
            if(objDeliveyman == null)
            {
                AddError("Deliveryman not found");
                return;
            }
            if(objDeliveyman.IdCurrentCompanyBranch == null || objDeliveyman.IdCurrentCompanyBranch != forwardToDeDeliveryman.IdCompanyBranch)
            {
                AddError("Deliveryman not forward to companybranch");
                return;
            }

            var objQueues = _queueRepository.Get(forwardToDeDeliveryman.Items.Select(p => p.IdQueue).ToArray(), new []{ "DeliveryAddress.Address" });
            if (objQueues.Length < forwardToDeDeliveryman.Items.Count)
            {
                AddError("Order not found");
                return;
            }

            Address currentAddress = null;
            foreach (var item in forwardToDeDeliveryman.Items.OrderBy(p=> p.Position))
            {
                var queue = objQueues.First(p => p.IdQueue == item.IdQueue);
                queue.Forward(forwardToDeDeliveryman.IdDeliveryman, item.Position, currentAddress?.CalculateDistence(queue.DeliveryAddress.Address.Latitude, queue.DeliveryAddress.Address.Longitude) ?? queue.CalcDeliveryTime());
                currentAddress = queue.DeliveryAddress.Address;
                //TODO prepare push notification
            }

            if(Commit())
            { //TODO Push notification
            }
        }

        public QueueViewModel[] GetBasicforwarded(int idDeliveryman)
        {
            return _queueRepository.GetBasicforwardedDapper(idDeliveryman);
        }

        public QueueViewModel[] GetBasicNotforwarded(int idCompanyBranch)
        {
            return _queueRepository.GetBasicNotforwardedDapper(idCompanyBranch);
        }

        public void SetPreparationTime(PreparationTimeViewModel[] preparationTimeViewModels)
        {
            var orders = _orderRepository.Get(preparationTimeViewModels.Select(p => p.IdOrder).ToArray());
            if(orders == null)
            {
                AddError("Order not found");
                return;
            }
            foreach (var order in orders)
            {
                order.SetPreparationTime(preparationTimeViewModels.First(p => p.IdOrder == order.IdOrder).Minutes);
                //TODO prepare push notification
            }

            if (Commit())
            { //TODO Push notification
            }
        }
    }
}