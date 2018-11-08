using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;

namespace TrackingFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeApplication _employeeApplication;
        public EmployeeController(IDomainEvent domainEvent, IEmployeeApplication employeeApplication) : base(domainEvent)
        {
            _employeeApplication = employeeApplication;
        }
        [HttpGet]
        public Task<ObjectResult> Get(int idCompanyBranch)
        {
            return CreateResponse(_employeeApplication.Get(idCompanyBranch));
        }
    }
}