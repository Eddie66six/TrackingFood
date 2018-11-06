using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : BaseApiController
    {
        private readonly IQueueApplication _queueApplication;
        public QueueController(IDomainEvent domainEvent, IQueueApplication queueApplication) : base(domainEvent)
        {
            _queueApplication = queueApplication;
        }

        [HttpPost]
        public Task<ObjectResult> Create(CreateOrderViewModel createOrderViewModel)
        {
            return CreateResponse(_queueApplication.Create(createOrderViewModel));
        }
        [HttpPost]
        [Route("Forward")]
        public Task<ObjectResult> Forward(ForwardToDeDeliveryman forwardToDeDeliveryman)
        {
            _queueApplication.Forward(forwardToDeDeliveryman);
            return CreateResponse(null);
        }
        [HttpGet]
        public Task<ObjectResult> GetNotforwarded(int idCompanyBranch)
        {
            return CreateResponse(_queueApplication.GetBasicNotforwarded(idCompanyBranch));
        }
        [HttpGet]
        [Route("Forwarded")]
        public Task<ObjectResult> GetForwarded(int idDeliveryman)
        {
            return CreateResponse(_queueApplication.GetBasicforwarded(idDeliveryman));
        }
    }
}