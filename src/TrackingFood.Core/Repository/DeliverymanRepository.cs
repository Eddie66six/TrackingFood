using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class DeliverymanRepository : BaseRepository<Deliveryman>, IDeliverymanRepository
    {
        public DeliverymanRepository(Context context) : base(context)
        {
        }

        public Deliveryman[] GetForCurrentCompanyBranchDapper(int idCompanyBranch)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.Query<Deliveryman>("select * from Deliverymen where IdCurrentCompanyBranch = @idCompanyBranch", new { idCompanyBranch }).ToArray();
            }
        }

        public Deliveryman Get(int idDeliveryman)
        {
            return _context.Deliverymen.FirstOrDefault(p => p.IdDeliveryman == idDeliveryman);
        }
    }
}