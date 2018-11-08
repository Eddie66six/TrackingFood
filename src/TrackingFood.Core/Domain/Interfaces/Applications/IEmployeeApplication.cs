using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IEmployeeApplication : IBaseApplication
    {
        Employee[] Get(int idCompanyBranch);
    }
}
