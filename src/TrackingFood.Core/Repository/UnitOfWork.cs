using System;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class UnitOfWork : DomainEvent, IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                if (IsError()) return false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                AddError(e.Message);
                return false;
            }
        }
    }
}