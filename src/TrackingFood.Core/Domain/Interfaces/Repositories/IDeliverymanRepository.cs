using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IDeliverymanRepository : IBaseRepository<Deliveryman>
    {
        Deliveryman[] GetForCurrentCompanyBranchDapper(int idCompanyBranch);
        Deliveryman Get(int idDeliveryman);
    }
}