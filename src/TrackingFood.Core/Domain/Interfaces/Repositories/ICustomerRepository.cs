using System.Collections.Generic;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetCustomer(int id);
        bool ExistEmail(string email);
    }
}