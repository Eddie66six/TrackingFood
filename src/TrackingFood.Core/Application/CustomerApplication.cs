using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Application
{
    public class CustomerApplication : BaseApplication, ICustomerApplication
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerApplication(Context context, ICustomerRepository customerRepository) : base(context)
        {
            _customerRepository = customerRepository;
        }
        public void Create(string name)
        {
            var customer = new Customer(name,
                new DeliveryAddress("Sorocaba", "Emiliano ramos, quintais do imperador 2", "399"));
            _customerRepository.Create(customer);
            Commit();
        }
    }
}