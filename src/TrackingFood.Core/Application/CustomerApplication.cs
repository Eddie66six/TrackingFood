using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;
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
        public void Create(CreateCustomerViewModel customer)
        {
            var objCustomer = new Customer(customer.Name,customer.DocumentNumber,
                new DeliveryAddress(customer.City, customer.Address, customer.FullNumber), new Credencial(customer.Email, customer.Password));
            _customerRepository.Create(objCustomer);
            if (!IsError() && _customerRepository.ExistEmail(objCustomer.Credencial.Email))
                AddError("Email already exists");
            Commit();
        }
    }
}