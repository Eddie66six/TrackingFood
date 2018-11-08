namespace TrackingFood.Core.Domain
{
    public interface IDomainEvent
    {
        void AddError(string message, string details = null, string callerMemberName = null);
        bool IsError();
        DomainEventContainer[] GetErrorMessages();
    }
}