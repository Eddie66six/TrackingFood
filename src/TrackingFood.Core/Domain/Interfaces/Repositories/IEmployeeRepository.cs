using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        Employee[] GetDapper(int idCompanyBranch);
    }
}
