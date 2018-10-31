using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Order : Entity
    {
        public int IdOrder { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal DeliveryValue { get; set; }
    }
}