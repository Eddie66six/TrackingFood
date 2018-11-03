using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredencialController : BaseApiController
    {
        private readonly ICredencialApplication _credencialApplication;
        public CredencialController(ICredencialApplication credencialApplication, IDomainEvent domainEvent) : base(domainEvent)
        {
            _credencialApplication = credencialApplication;
        }

        [HttpPut]
        public Task<ObjectResult> Update(UpdateCredencialViewModel updateCredencialViewModel)
        {
            _credencialApplication.Update(updateCredencialViewModel);
            return CreateResponse(null);
        }
    }
}