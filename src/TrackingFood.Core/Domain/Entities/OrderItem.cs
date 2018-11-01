namespace TrackingFood.Core.Domain.Entities
{
    public sealed class OrderItem : Entity
    {
        private OrderItem()
        {
            
        }
        public OrderItem( MenuItem menuItem)
        {
            Validate();
        }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
        public int IdOrderItem { get; set; }
        public int IdMenuItem { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
    }
}