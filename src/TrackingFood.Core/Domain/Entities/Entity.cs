namespace TrackingFood.Core.Domain.Entities
{
    public abstract class Entity : DomainEvent
    {
        protected abstract void Validate();
    }
}