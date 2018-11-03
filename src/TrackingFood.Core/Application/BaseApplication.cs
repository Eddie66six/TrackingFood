using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;

namespace TrackingFood.Core.Application
{
    public class BaseApplication : DomainEvent, IBaseApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected bool Commit()
        {
            return _unitOfWork.Commit();
        }
    }
}