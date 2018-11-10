namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Queue : Entity
    {
        private Queue()
        {
            
        }
        public Queue(int idDeliveryAddress, Order order, int idCompanyBrach, double distance)
        {
            IdDeliveryAddress = idDeliveryAddress;
            Order = order;
            IdCompanyBranch = idCompanyBrach;
            Distance = distance;
            Validate();
        }
        protected override void Validate()
        {
            if (IdDeliveryAddress <= 0 || Order == null || IdCompanyBranch <= 0 || Distance <= 0)
                AddError("Invalid queue");
        }

        public void Forward(int idDeliveryman, int position)
        {
            IdDeliveryman = idDeliveryman;
            Position = position;
        }
        public int IdQueue { get; set; }
        public int IdDeliveryAddress { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public int? IdDeliveryman { get; set; }
        public Deliveryman Deliveryman { get; set; }
        public int? Position { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
        public int IdCompanyBranch { get; set; }
        public CompanyBranch CompanyBranch { get; set; }
        public double Distance { get; set; }
    }
}