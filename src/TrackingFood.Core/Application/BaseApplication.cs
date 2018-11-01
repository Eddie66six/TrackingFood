using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Application
{
    public class BaseApplication : DomainEvent, IBaseApplication
    {
        private readonly Context _context;
        public BaseApplication(Context context)
        {
            _context = context;
        }

        protected bool Commit()
        {
            if (IsError()) return false;
            _context.SaveChanges();
            return true;
        }
    }
}