namespace TrackingFood.Core.Domain.ViewModel
{
    public class QueueViewModel
    {
        public int IdQueue { get; set; }
        public decimal DeliveryValue { get; set; }
        public decimal TotalValue { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string FullNumber { get; set; }
    }
}