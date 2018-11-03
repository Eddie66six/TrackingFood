using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IMenuApplication: IBaseApplication
    {
        int? Create(CreateMenuViewModel menu);
        Menu GetWithItems(int id);
    }
}