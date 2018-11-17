using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.ViewModel;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface ICompanyBranchRepository : IBaseRepository<CompanyBranch>
    {
        CompanyBranch Get(int id, string[] includes = null);
        bool ExistCompanyNameDapper(string name);
        SearchCompanyBranchViewModel[] SearchForName(string strSearch);
    }
}