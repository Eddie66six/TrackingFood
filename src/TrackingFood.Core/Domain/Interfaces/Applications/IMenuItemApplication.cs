using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IMenuItemApplication : IBaseApplication
    {
        void Create(CreateMenuItemsViewModel menuItem);
    }
}