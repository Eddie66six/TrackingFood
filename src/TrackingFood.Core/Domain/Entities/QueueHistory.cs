using System;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class QueueHistory : Entity
    {
        public int IdQueueHistory { get; set; }
        public int Position { get; set; }
        public int IdDeliveryAddress { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public int IdDeliveryman { get; set; }
        public Deliveryman Deliveryman { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}