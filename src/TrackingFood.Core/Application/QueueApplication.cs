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
        public QueueApplication(IUnitOfWork unitOfWork, IQueueRepository queueRepository) : base(unitOfWork)
        {
            _queueRepository = queueRepository;
        }

        public int? Create(CreateOrderViewModel order)
        {
            var objOrder = new Order(order.Items.Select(p => new OrderItem(p.IdMenuItem, p.Amount)).ToList(),
                order.DeliveryValue, order.IdCompanyBranch, order.IdCustomer);

            if (IsError())
                return null;
            var objQueue = new Queue(order.IdDeliveryAddress, objOrder, objOrder.IdCompanyBranch);
            _queueRepository.Create(objQueue);
            if (Commit())
                return objQueue.IdQueue;
            return null;
        }

        public void Forward(ForwardToDeDeliveryman forwardToDeDeliveryman)
        {
            if (forwardToDeDeliveryman.Items.GroupBy(p => p.Position).Select(p => p.Count()).Any(p => p > 1))
            {
                AddError("Duplicate position");
                return;
            }

            var objQueues = _queueRepository.Get(forwardToDeDeliveryman.Items.Select(p => p.IdQueue).ToArray());
            foreach (var item in objQueues)
            {
                item.Forward(forwardToDeDeliveryman.IdDeliveryman, forwardToDeDeliveryman.Items.First(p => p.IdQueue == item.IdQueue).Position);
            }

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
    }
}