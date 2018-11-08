using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;

namespace TrackingFood.Core.Application
{
    public class EmployeeApplication : BaseApplication, IEmployeeApplication
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeApplication(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository) : base(unitOfWork)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee[] Get(int idCompanyBranch)
        {
            return _employeeRepository.GetDapper(idCompanyBranch);
        }
    }
}
