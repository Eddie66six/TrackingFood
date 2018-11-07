using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IEmployeeApplication : IBaseApplication
    {
        Employee[] GetCurrentEmployees(int idCompanyBranch);
    }
}
