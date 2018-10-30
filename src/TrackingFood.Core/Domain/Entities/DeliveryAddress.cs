using System;

namespace TrackingFood.Core.Domain.Entities
{
    public class DeliveryAddress
    {
        public int IdDeliveryAddress { get; set; }
        public int Address { get; set; }
        public string FullNumber { get; set; }
        public int IdCustomer { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
