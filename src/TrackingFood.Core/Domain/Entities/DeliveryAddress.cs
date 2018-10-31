using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class DeliveryAddress : Entity
    {
        public int IdDeliveryAddress { get; set; }
        public string Address { get; set; }
        public string FullNumber { get; set; }
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Queue> Queues { get; set; }
    }
}
