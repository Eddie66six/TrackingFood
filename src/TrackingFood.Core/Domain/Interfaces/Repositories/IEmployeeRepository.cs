using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        Employee[] GetCurrentEmployeesDapper(int idCompanyBranch);
    }
}
