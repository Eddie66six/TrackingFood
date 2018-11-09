using System;
using System.Data.SqlClient;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.ViewModel;

namespace TrackingFood.Core.Repository
{
    public class QueueRepository : BaseRepository<Queue>, IQueueRepository
    {
        public QueueRepository(Context context) : base(context)
        {
        }

        public Queue[] Get(int[] ids)
        {
            return _context.Queues.Where(p => ids.Contains(p.IdQueue)).ToArray();
        }

        public QueueViewModel[] GetBasicNotforwardedDapper(int idCompanyBranch)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var date = DateTime.Now.ToString("yyyMMdd");
                return con.Query<QueueViewModel>(@"select q.IdQueue,o.DeliveryValue, total.value as TotalValue, d.City,d.Address,d.FullNumber
                        from Queues q inner join Orders o on o.IdOrder = q.IdOrder inner join DeliveryAddresses d on d.IdDeliveryAddress = q.IdDeliveryAddress
                        CROSS APPLY(select SUM(m.Value) as value from OrderItems oi inner join MenuItems m on m.IdMenuItens = oi.IdMenuItem where oi.IdOrder = o.idOrder) as total
                        where q.IdDeliveryman is null and q.IdCompanyBranch = @idCompanyBranch and CONVERT(date, o.Date) = @date", new { idCompanyBranch, date }).ToArray();
            }
        }
        public QueueViewModel[] GetBasicforwardedDapper(int idDeliveryman)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var date = DateTime.Now.ToString("yyyMMdd");
                return con.Query<QueueViewModel>(@"select q.IdQueue,o.DeliveryValue, total.value as TotalValue, d.City,d.Address,d.FullNumber
                        from Queues q inner join Orders o on o.IdOrder = q.IdOrder inner join DeliveryAddresses d on d.IdDeliveryAddress = q.IdDeliveryAddress
                        CROSS APPLY(select SUM(m.Value) as value from OrderItems oi inner join MenuItems m on m.IdMenuItens = oi.IdMenuItem where oi.IdOrder = o.idOrder) as total
                        where q.IdCompanyBranch = @IdDeliveryman and CONVERT(date, o.Date) = @date order by q.Position", new { idDeliveryman, date }).ToArray();
            }
        }

        public Queue Get(int id, string[] includes = null)
        {
            var query = _context.Queues.Where(p => p.IdQueue == id);
            if(includes == null)
                return query.FirstOrDefault();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault();
        }
    }
}