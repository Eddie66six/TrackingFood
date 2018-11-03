using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Application
{
    public class MenuApplication : BaseApplication, IMenuApplication
    {
        private readonly IMenuRepository _menuRepository;
        public MenuApplication(IUnitOfWork unitOfWork, IMenuRepository menuRepository) : base(unitOfWork)
        {
            _menuRepository = menuRepository;
        }

        public int? Create(CreateMenuViewModel menu)
        {
            var objMenu = new Menu(menu.Name, menu.IdCompanyBranch);
            _menuRepository.Create(objMenu);
            if (!IsError() && _menuRepository.ExistMenuNameDapper(objMenu.IdCompanyBranch , objMenu.Name))
                AddError("Menu already exists");

            if (Commit())
                return objMenu.IdMenu;
            return null;
        }

        public Menu GetWithItems(int id)
        {
            return _menuRepository.GetWithItemsDapper(id);
        }
    }
}