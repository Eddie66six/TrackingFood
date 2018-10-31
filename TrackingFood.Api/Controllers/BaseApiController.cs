using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingFood.Core.Domain;

namespace TrackingFood.Api.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private readonly IDomainEvent _domainEvent;
        public BaseApiController(IDomainEvent domainEvent)
        {
            _domainEvent = domainEvent;
        }
        public Task<ObjectResult> CreateResponse(object result, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return Task.FromResult(_domainEvent.IsError() ? StatusCode((int)HttpStatusCode.BadRequest, _domainEvent.GetErrorMessages()) : StatusCode((int)httpStatusCode, result));
        }
    }
}