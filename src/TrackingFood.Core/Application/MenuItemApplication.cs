using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Application
{
    public class MenuItemApplication: BaseApplication, IMenuItemApplication
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuItemApplication(IUnitOfWork unitOfWork, IMenuItemRepository menuItemRepository) : base(unitOfWork)
        {
            _menuItemRepository = menuItemRepository;
        }

        public int? Create(CreateMenuItemViewModel menuItem)
        {
            var objMenuItem = new MenuItem(menuItem.Name, menuItem.Description, menuItem.UrlImage, menuItem.Value, menuItem.IdMenu);
            _menuItemRepository.Create(objMenuItem);
            if (!IsError() && _menuItemRepository.ExistMenuItemNameDapper(objMenuItem.IdMenu, objMenuItem.Name))
                AddError("Menu Item already exists");

            if (Commit())
                return objMenuItem.IdMenuItens;
            return null;
        }
    }
}