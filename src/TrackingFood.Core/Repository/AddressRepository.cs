using System.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(Context context) : base(context)
        {
        }

        public Address GetDapper(int id)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<Address>(@"select a.* from Addresses where IdAddress = @id", new { id });
            }
        }

        public Address GetDelivereyAddressDapper(int idDeliveryAddress)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<Address>(@"SELECT a.* from DeliveryAddresses d
                        inner join Addresses a on a.IdAddress = d.IdAddress where d.IdDeliveryAddress = @idDeliveryAddress", new { idDeliveryAddress });
            }
        }

        public Address GetCompanyBranchDapper(int idCompanyBranch)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<Address>(@"select a.* from CompanyBranches c
                        inner JOIN Addresses a on a.IdAddress = c.IdAddress where c.IdCompanyBranch = @idCompanyBranch", new { idCompanyBranch });
            }
        }
    }
}