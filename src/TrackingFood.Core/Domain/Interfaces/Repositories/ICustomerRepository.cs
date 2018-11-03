using System.Collections.Generic;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer Get(int id);
        bool ExistEmailDapper(string email);
    }
}