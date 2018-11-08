using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Application
{
    public class DeliverymanApplication : BaseApplication, IDeliverymanApplication
    {
        private readonly IDeliverymanRepository _deliverymanRepository;
        public DeliverymanApplication(IUnitOfWork unitOfWork, IDeliverymanRepository deliverymanRepository) : base(unitOfWork)
        {
            _deliverymanRepository = deliverymanRepository;
        }

        public Deliveryman[] GetForCurrentCompanyBranch(int idCompanyBranch)
        {
            return _deliverymanRepository.GetForCurrentCompanyBranchDapper(idCompanyBranch);
        }

        public int? Create(CreateDeliverymanViewModel deliveryman)
        {
            var objDeliveryman = new Deliveryman(deliveryman.Name);
            _deliverymanRepository.Create(objDeliveryman);

            if (Commit())
                return objDeliveryman.IdDeliveryman;
            return null;
        }

        public Deliveryman Get(int idDeliveryman)
        {
            return _deliverymanRepository.Get(idDeliveryman);
        }

        public void BindToCompanyBranch(int idDeliveryman, int idCompanyBranch)
        {
            var objDeliveryman = _deliverymanRepository.Get(idDeliveryman);
            if (objDeliveryman == null)
            {
                AddError("Deliveryman not found");
                return;
            }

            objDeliveryman.SetCurrentCompanyBranch(idCompanyBranch);
            Commit();
        }
    }
}