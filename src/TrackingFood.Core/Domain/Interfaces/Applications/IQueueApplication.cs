using TrackingFood.Core.Domain.ViewModel;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IQueueApplication : IBaseApplication
    {
        int? Create(CreateOrderViewModel order);
        void Forward(ForwardToDeDeliveryman forwardToDeDeliveryman);
        QueueViewModel[] GetBasicNotforwarded(int idCompanyBranch);
        QueueViewModel[] GetBasicforwarded(int idDeliveryman);
        void DeliverOrder(int idQueue);
        void SetPreparationTime(int idQueue, double minutes);
    }
}