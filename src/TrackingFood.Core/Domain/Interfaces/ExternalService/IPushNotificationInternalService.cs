namespace TrackingFood.Core.Domain.Interfaces.ExternalService
{
    public interface IPushNotificationInternalService
    {
        void NextOrder(int position, double minutes);
    }
}
