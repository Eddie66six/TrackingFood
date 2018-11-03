using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface ICredencialRepository : IBaseRepository<Credencial>
    {
        Credencial Get(int idCustomer);
    }
}