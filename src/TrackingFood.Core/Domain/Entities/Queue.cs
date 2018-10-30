using System;

namespace TrackingFood.Core.Domain.Entities
{
    public class Queue
    {
        public int Position { get; set; }
        public int IdDeliveryAddress { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }
        public int IdDeliveryman { get; set; }
        public virtual Deliveryman Deliveryman { get; set; }
    }
}