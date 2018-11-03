namespace TrackingFood.Core.Domain
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}