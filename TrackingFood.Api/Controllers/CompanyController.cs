using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyApplication _companyApplication;
        private readonly ICompanyBranchApplication _companyBranchApplication;
        public CompanyController(IDomainEvent domainEvent, ICompanyApplication companyApplication, ICompanyBranchApplication companyBranchApplication) : base(domainEvent)
        {
            _companyApplication = companyApplication;
            _companyBranchApplication = companyBranchApplication;
        }

        [HttpPost]
        public Task<ObjectResult> Create(CreateCompanyViewModel createCompanyViewModel)
        {
            return CreateResponse(_companyApplication.Create(createCompanyViewModel));
        }
        [HttpPost]
        [Route("Branch")]
        public Task<ObjectResult> Create(CreateCompanyBranchViewModel createCompanyBranchViewModel)
        {
            return CreateResponse(_companyBranchApplication.Create(createCompanyBranchViewModel));
        }
        [HttpGet]
        [Route("Search/Name")]
        public Task<ObjectResult> SearchForName(double latitude, double longitude, string strSearch)
        {
            return CreateResponse(_companyBranchApplication.SearchForName(latitude, longitude, strSearch));
        }
    }
}