using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Application
{
    public class CredencialApplication : BaseApplication, ICredencialApplication
    {
        private readonly ICredencialRepository _credencialRepository;
        public CredencialApplication(IUnitOfWork unitOfWork, ICredencialRepository credencialRepository) : base(unitOfWork)
        {
            _credencialRepository = credencialRepository;
        }

        public void Update(UpdateCredencialViewModel credencial)
        {
            var objCredencial = _credencialRepository.Get(credencial.IdCustomer);
            objCredencial.Update(credencial.NewPassword);
            Commit();
        }
    }
}