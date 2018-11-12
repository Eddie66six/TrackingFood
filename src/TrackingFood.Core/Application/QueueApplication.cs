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
        public QueueApplication(IUnitOfWork unitOfWork, IQueueRepository queueRepository, IQueueHistoryRepository queueHistoryRepository,
            IDeliverymanRepository deliverymanRepository, ICompanyBranchRepository companyBranchRepository, IAddressRepository addressRepository) : base(unitOfWork)
        {
            _queueRepository = queueRepository;
            _queueHistoryRepository = queueHistoryRepository;
            _deliverymanRepository = deliverymanRepository;
            _companyBranchRepository = companyBranchRepository;
            _addressRepository = addressRepository;
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

            var objQueues = _queueRepository.Get(forwardToDeDeliveryman.Items.Select(p => p.IdQueue).ToArray());
            foreach (var item in objQueues)
            {
                item.Forward(forwardToDeDeliveryman.IdDeliveryman, forwardToDeDeliveryman.Items.First(p => p.IdQueue == item.IdQueue).Position);
            }

            var objCompanyBranch = _companyBranchRepository.Get(forwardToDeDeliveryman.IdCompanyBranch);
            if (objCompanyBranch == null)
            {
                AddError("Company branch not found");
                return;
            }
            //calculate distance

            Commit();
        }

        public QueueViewModel[] GetBasicforwarded(int idDeliveryman)
        {
            return _queueRepository.GetBasicforwardedDapper(idDeliveryman);
        }

        public QueueViewModel[] GetBasicNotforwarded(int idCompanyBranch)
        {
            return _queueRepository.GetBasicNotforwardedDapper(idCompanyBranch);
        }

        public void SetPreparationTime(int idQueue, double minutes)
        {
            var objQueue = _queueRepository.Get(idQueue);
            if (objQueue == null)
            {
                AddError("Queue not found");
                return;
            }
            objQueue.SetPreparationTime(minutes);
            Commit();
        }
    }
}