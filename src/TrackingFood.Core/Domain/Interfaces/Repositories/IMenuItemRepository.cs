using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IMenuItemRepository: IBaseRepository<MenuItem>
    {
        MenuItem Get(int id);
        bool ExistMenuItemNameDapper(int idMenu, string name);
        bool ExistMenuItemNameDapper(int idMenu, string[] names);
        MenuItem[] CreateRange(MenuItem[] menuItems);
    }
}