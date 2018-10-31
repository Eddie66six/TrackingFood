namespace TrackingFood.Core.Domain.Entities
{
    public sealed class OrderItem : Entity
    {
        public int IdOrderItem { get; set; }
        public int IdMenuItem { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
    }
}