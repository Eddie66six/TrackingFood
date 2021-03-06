﻿using System.Data.SqlClient;
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

        public Queue[] Get(int[] ids, string[] includes = null)
        {
            var query = _context.Queues.Where(p => ids.Contains(p.IdQueue));
            if (includes == null)
                return query.ToArray();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToArray();
        }

        public QueueViewModel[] GetBasicNotforwardedDapper(int idCompanyBranch)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.Query<QueueViewModel>(@"select q.IdQueue, q.IdCompanyBranch, o.DeliveryValue, total.value as TotalValue, a.City,a.AddressDescription,a.FullNumber, q.Distance
                        from Queues q inner join Orders o on o.IdOrder = q.IdOrder inner join DeliveryAddresses d on d.IdDeliveryAddress = q.IdDeliveryAddress inner join Addresses a on a.idAddress = d.idAddress
                        CROSS APPLY(select SUM(m.Value) as value from OrderItems oi inner join MenuItems m on m.IdMenuItens = oi.IdMenuItem where oi.IdOrder = o.idOrder) as total
                        where q.IdDeliveryman is null and q.IdCompanyBranch = @idCompanyBranch order by q.Distance", new { idCompanyBranch }).ToArray();
            }
        }
        public QueueViewModel[] GetBasicforwardedDapper(int idDeliveryman)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.Query<QueueViewModel>(@"select q.IdQueue, q.IdCompanyBranch, q.DeliveryTime, o.DeliveryValue, total.value as TotalValue, a.City, A.AddressDescription,a.FullNumber, q.Distance
                        from Queues q inner join Orders o on o.IdOrder = q.IdOrder inner join DeliveryAddresses d on d.IdDeliveryAddress = q.IdDeliveryAddress inner join Addresses a on a.idAddress = d.idAddress
                        CROSS APPLY(select SUM(m.Value) as value from OrderItems oi inner join MenuItems m on m.IdMenuItens = oi.IdMenuItem where oi.IdOrder = o.idOrder) as total
                        where q.IdDeliveryman = @idDeliveryman order by q.Position", new { idDeliveryman }).ToArray();
            }
        }

        public Queue Get(int id, string[] includes = null)
        {
            var query = _context.Queues.Where(p => p.IdQueue == id);
            if(includes == null)
                return query.FirstOrDefault();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.FirstOrDefault();
        }
    }
}