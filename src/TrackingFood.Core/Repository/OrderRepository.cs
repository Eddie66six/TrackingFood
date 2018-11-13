using System.Linq;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }

        public Order[] Get(int[] ids)
        {
            return _context.Orders.Where(p => ids.Contains(p.IdOrder)).ToArray();
        }
    }
}
