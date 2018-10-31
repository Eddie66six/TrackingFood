using System.Collections.Generic;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        void Create();
        Customer GetCustomers(int id);
    }
}