using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerApplication _customerApplication;
        public CustomerController(ICustomerApplication customerApplication, IDomainEvent domainEvent) : base(domainEvent)
        {
            _customerApplication = customerApplication;
        }
        [HttpPost]
        public Task<ObjectResult> Create(CreateCustomerViewModel createCustomerViewModel)
        {
            return CreateResponse(_customerApplication.Create(createCustomerViewModel));
        }
        [HttpPut]
        public Task<ObjectResult> Update(UpdateCustomerViewModel updateCustomerViewModel)
        {
            _customerApplication.Update(updateCustomerViewModel);
            return CreateResponse(null);
        }
    }
}