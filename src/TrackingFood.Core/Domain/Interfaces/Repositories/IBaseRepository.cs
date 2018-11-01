namespace TrackingFood.Core.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Create(T entity);
    }
}