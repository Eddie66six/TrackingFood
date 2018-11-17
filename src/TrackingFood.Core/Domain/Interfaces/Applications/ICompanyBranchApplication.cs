using TrackingFood.Core.Domain.ViewModel;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface ICompanyBranchApplication : IBaseApplication
    {
        int? Create(CreateCompanyBranchViewModel companyBranch);
        SearchCompanyBranchViewModel[] SearchForName(string strSearch);
    }
}