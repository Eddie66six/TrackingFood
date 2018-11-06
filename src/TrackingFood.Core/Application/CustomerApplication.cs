using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Application
{
    public class CustomerApplication : BaseApplication, ICustomerApplication
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerApplication(IUnitOfWork unitOfWork, ICustomerRepository customerRepository) : base(unitOfWork)
        {
            _customerRepository = customerRepository;
        }
        public int? Create(CreateCustomerViewModel customer)
        {
            var objCustomer = new Customer(customer.Name, customer.DocumentNumber,
                new DeliveryAddress(customer.City, customer.Address, customer.FullNumber, customer.Latitude, customer.Longitude), new Credencial(customer.Email, customer.Password));
            _customerRepository.Create(objCustomer);
            if (!IsError() && _customerRepository.ExistEmailDapper(objCustomer.Credencial.Email))
                AddError("Email already exists");

            if (Commit())
                return objCustomer.IdCustomer;
            return null;
        }

        public void Update(UpdateCustomerViewModel customer)
        {
            var objCustomer = _customerRepository.Get(customer.IdCustomer);
            if (objCustomer == null)
            {
                AddError("Customer not found");
                return;
            }
            objCustomer.Update(customer.Name, objCustomer.DocumentNumber);
            Commit();
        }
    }
}