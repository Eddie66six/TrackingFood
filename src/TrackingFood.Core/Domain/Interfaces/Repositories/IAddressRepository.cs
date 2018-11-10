using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.ViewModel;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Address GetDapper(int id);
        Address GetDelivereyAddressDapper(int idDeliveryAddress);
        Address GetCompanyBranchDapper(int idCompanyBranch);
    }
}