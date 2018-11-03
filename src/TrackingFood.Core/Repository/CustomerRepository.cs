using System.Data.SqlClient;
using Dapper;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TrackingFood.Core.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context) : base(context)
        {
        }

        //public Customer Get(int id)
        //{
        //    using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //    {
        //        return con.QueryFirstOrDefault<Customer>("select * from Customers where IdCustomer = @id", new { id });
        //        //var sql = $"SELECT * from Customers c inner join DeliveryAddresses d on d.IdCustomer = c.IdCustomer where c.IdCustomer = {id}";
        //        //var orderDictionary = new Dictionary<int, Customer>();

        //        //one to many
        //        //return con.Query<Customer, DeliveryAddress, Customer>(
        //        //        sql,
        //        //        (order, orderDetail) =>
        //        //        {
        //        //            if (!orderDictionary.TryGetValue(order.IdCustomer, out var customer))
        //        //            {
        //        //                customer = order;
        //        //                customer.Adresses = new List<DeliveryAddress>();
        //        //                orderDictionary.Add(customer.IdCustomer, customer);
        //        //            }

        //        //            customer.Adresses.Add(orderDetail);
        //        //            return customer;
        //        //        },
        //        //        splitOn: "IdDeliveryAddress")
        //        //    .FirstOrDefault();
        //        //one to one
        //        //var invoices = con.Query<Customer, List<DeliveryAddress>, Customer>(
        //        //        sql,
        //        //        (invoice, invoiceDetail) =>
        //        //        {
        //        //            invoice.Adresses = invoiceDetail;
        //        //            return invoice;
        //        //        },
        //        //        splitOn: "IdDeliveryAddress")
        //        //    .ToList();
        //    }
        //}

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.IdCredencial == id);
        }

        public bool ExistEmailDapper(string email)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<bool>("select top 1 1 from Customers c inner join Credencials ce on ce.IdCredencial = c.IdCredencial where ce.Email = @email", new { email });
            }
        }
    }
}