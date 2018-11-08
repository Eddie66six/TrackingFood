using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IDeliverymanApplication : IBaseApplication
    {
        Deliveryman[] GetForCurrentCompanyBranch(int idCompanyBranch);
        int? Create(CreateDeliverymanViewModel deliveryman);
        Deliveryman Get(int idDeliveryman);
        void BindToCompanyBranch(int idDeliveryman, int idCompanyBranch);
    }
}