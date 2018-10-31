using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;

namespace TrackingFood.Core.Application
{
    public class CustomerApplication : BaseApplication, ICustomerApplication
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerApplication(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Create(string name)
        {
            var customers =_customerRepository.GetCustomers(0);
            AddError("teste");
        }
    }
}