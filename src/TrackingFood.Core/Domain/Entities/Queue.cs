namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Queue : Entity
    {
        private Queue()
        {
            
        }
        public Queue(int position)
        {
            Validate();
        }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
        public int IdQueue { get; set; }
        public int Position { get; set; }
        public int IdDeliveryAddress { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public int IdDeliveryman { get; set; }
        public Deliveryman Deliveryman { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
        public int IdCompanyBranch { get; set; }
        public CompanyBranch CompanyBranch { get; set; }
    }
}