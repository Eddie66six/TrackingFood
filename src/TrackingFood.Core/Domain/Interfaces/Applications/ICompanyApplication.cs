using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface ICompanyApplication : IBaseApplication
    {
        int? Create(CreateCompanyViewModel company);
    }
}