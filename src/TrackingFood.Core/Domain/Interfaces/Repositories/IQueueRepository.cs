using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.ViewModel;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IQueueRepository : IBaseRepository<Queue>
    {
        Queue[] Get(int[] ids);
        Queue Get(int id, string[] includes = null);
        QueueViewModel[] GetBasicNotforwardedDapper(int idCompanyBranch);
        QueueViewModel[] GetBasicforwardedDapper(int idDeliveryman);
    }
}