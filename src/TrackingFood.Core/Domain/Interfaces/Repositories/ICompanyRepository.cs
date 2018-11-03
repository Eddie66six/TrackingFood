using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Company Get(int id);
        bool ExistCompanyNameDapper(string name);
    }
}