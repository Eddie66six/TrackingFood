using System.Linq;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class CredencialRepository : BaseRepository<Credencial>, ICredencialRepository
    {
        public CredencialRepository(Context context) : base(context)
        {
        }

        public Credencial Get(int idCustomer)
        {
            return _context.Credencials.FirstOrDefault(p => p.Customer.IdCustomer == idCustomer);
        }
    }
}