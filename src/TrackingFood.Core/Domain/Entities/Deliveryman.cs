using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Deliveryman : Entity
    {
        public int IdDeliveryman { get; set; }
        public string Name { get; set; }
        public IEnumerable<Queue> Queues { get; set; }
    }
}