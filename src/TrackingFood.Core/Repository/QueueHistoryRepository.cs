using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class QueueHistoryRepository : BaseRepository<QueueHistory>, IQueueHistoryRepository
    {
        public QueueHistoryRepository(Context context) : base(context)
        {
        }
    }
}
