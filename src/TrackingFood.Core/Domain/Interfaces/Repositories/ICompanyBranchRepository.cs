using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface ICompanyBranchRepository : IBaseRepository<CompanyBranch>
    {
        CompanyBranch Get(int id, string[] includes = null);
        bool ExistCompanyNameDapper(string name);
    }
}