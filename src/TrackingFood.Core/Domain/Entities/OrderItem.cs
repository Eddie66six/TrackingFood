namespace TrackingFood.Core.Domain.Entities
{
    public sealed class OrderItem : Entity
    {
        private OrderItem()
        {
            
        }
        public OrderItem(MenuItem menuItem, int amount)
        {
            MenuItem = menuItem;
            Amount = amount;
            Validate();
        }
        public OrderItem(int idMenuItem, int amount)
        {
            IdMenuItem = idMenuItem;
            Amount = amount;
            Validate();
        }
        protected override void Validate()
        {
            if (Amount <= 0)
                AddError("Invalid amount");
            if (MenuItem == null && IdMenuItem <= 0)
                AddError("Invalid item");
        }
        public int IdOrderItem { get; set; }
        public int IdMenuItem { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Amount { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
    }
}