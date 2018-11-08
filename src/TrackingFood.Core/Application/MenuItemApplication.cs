using System.Linq;
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

        public void Create(CreateMenuItemsViewModel menuItem)
        {
            if (menuItem.Items.GroupBy(p => p.Name).Select(p => p.Count()).Any(p => p > 1))
            {
                AddError("Duplicate item");
                return;
            }
            var itens = new MenuItem[menuItem.Items.Length];
            for (var index = 0; index < menuItem.Items.Length; index++)
            {
                itens[index] = new MenuItem(menuItem.Items[index].Name, menuItem.Items[index].Description, menuItem.Items[index].UrlImage, menuItem.Items[index].Value, menuItem.IdMenu);
            }

            if (!IsError() && _menuItemRepository.ExistMenuItemNameDapper(menuItem.IdMenu, itens.Select(p=> p.Name).ToArray()))
                AddError("Menu Item already exists");

            _menuItemRepository.CreateRange(itens);

            Commit();
        }
    }
}