using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IMenuItemApplication : IBaseApplication
    {
        int? Create(CreateMenuItemViewModel menuItem);
    }
}