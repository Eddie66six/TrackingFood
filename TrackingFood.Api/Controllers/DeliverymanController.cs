using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverymanController : BaseApiController
    {
        private readonly IDeliverymanApplication _deliverymanApplication;
        public DeliverymanController(IDomainEvent domainEvent, IDeliverymanApplication deliverymanApplication) : base(domainEvent)
        {
            _deliverymanApplication = deliverymanApplication;
        }

        [HttpGet]
        [Route("Branch")]
        public Task<ObjectResult> GetForCompanyBranch(int idCompanyBranch)
        {
            return CreateResponse(_deliverymanApplication.GetForCurrentCompanyBranch(idCompanyBranch));
        }
        [HttpPost]
        public Task<ObjectResult> Create(CreateDeliverymanViewModel createDeliverymanViewModel)
        {
            return CreateResponse(_deliverymanApplication.Create(createDeliverymanViewModel));
        }
        [HttpGet]
        public Task<ObjectResult> Get(int idDeliveryman)
        {
            return CreateResponse(_deliverymanApplication.Get(idDeliveryman));
        }
        [HttpPost]
        [Route("BindBranch")]
        public Task<ObjectResult> Bind(int idDeliveryman, int idCompanyBranch)
        {
            _deliverymanApplication.BindToCompanyBranch(idDeliveryman, idCompanyBranch);
            return CreateResponse(null);
        }
    }
}