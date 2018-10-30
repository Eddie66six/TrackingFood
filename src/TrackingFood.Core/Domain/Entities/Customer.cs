using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public int Name { get; set; }
        public virtual IEnumerable<DeliveryAddress> Adresses { get; set; }
    }
}