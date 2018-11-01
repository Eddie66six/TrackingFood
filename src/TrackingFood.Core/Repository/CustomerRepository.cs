using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context) : base(context)
        {
        }

        public Customer GetCustomers(int id)
        {
            //using (var con = new SqlConnection(
            //    _appsettings.ConnectionStrings.Dapper))
            //{
            //    return con.QueryFirstOrDefault<Customer>("select name from Customers where IdCustomer = @id", new { id });
            //}
            return null;
        }
    }
}