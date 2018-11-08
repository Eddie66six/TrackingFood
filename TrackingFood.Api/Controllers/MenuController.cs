using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseApiController
    {
        private readonly IMenuApplication _menuApplication;
        private readonly IMenuItemApplication _menuItemApplication;
        public MenuController(IDomainEvent domainEvent, IMenuApplication menuApplication, IMenuItemApplication menuItemApplication) : base(domainEvent)
        {
            _menuApplication = menuApplication;
            _menuItemApplication = menuItemApplication;
        }
        [HttpPost]
        public Task<ObjectResult> Create(CreateMenuViewModel createMenuViewModel)
        {
            return CreateResponse(_menuApplication.Create(createMenuViewModel));
        }
        [HttpPost]
        [Route("Item")]
        public Task<ObjectResult> Create(CreateMenuItemsViewModel  createMenuItemViewModel)
        {
            _menuItemApplication.Create(createMenuItemViewModel);
            return CreateResponse(null);
        }
        [HttpGet]
        [Route("Item")]
        public Task<ObjectResult> Get(int idMenu)
        {
            return CreateResponse(_menuApplication.GetWithItems(idMenu));
        }
    }

}