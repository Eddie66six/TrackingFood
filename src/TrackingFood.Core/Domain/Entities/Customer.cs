using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Customer : Entity
    {
        public int IdCustomer { get; set; }
        public int Name { get; set; }
        public IEnumerable<DeliveryAddress> Adresses { get; set; }
    }
}