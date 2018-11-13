namespace TrackingFood.Core.Domain.ViewModel
{
    public class QueueViewModel
    {
        public int IdCompanyBranch { get; set; }
        public int IdQueue { get; set; }
        public decimal DeliveryValue { get; set; }
        public decimal TotalValue { get; set; }
        public string City { get; set; }
        public string AddressDescription { get; set; }
        public string FullNumber { get; set; }
        public string Distance { get; set; }
        public double? DeliveryTime { get; set; }
    }
}