using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IMenuRepository: IBaseRepository<Menu>
    {
        Menu Get(int id);
        bool ExistMenuNameDapper(int idCompanyBranch, string name);
        Menu GetWithItemsDapper(int id);
    }
}