using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //IOptions<Appsettings> appsettings, 
        protected readonly Context _context;
        public BaseRepository(Context context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}