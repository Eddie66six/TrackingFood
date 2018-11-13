using System;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class QueueHistory : Entity
    {
        private QueueHistory()
        {
            
        }
        public QueueHistory(Queue queue)
        {
            Position = queue.Position.GetValueOrDefault();
            IdDeliveryman = queue.IdDeliveryman.GetValueOrDefault();
            IdDeliveryAddress = queue.IdDeliveryAddress;
            RequestDate = queue.Order.Date;
            DeliveryDate = DateTime.Now;
            IdOrder = queue.IdOrder;
            IdCompanyBranch = queue.IdCompanyBranch;
            Distance = queue.Distance;
            DeliveryTime = queue.DeliveryTime;
            Validate();
        }
        protected override void Validate()
        {
            if (Position == 0 || IdDeliveryman == 0)
                AddError("Invalid history");
        }
        public int IdQueueHistory { get; set; }
        public int Position { get; set; }
        public int IdDeliveryAddress { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public int IdDeliveryman { get; set; }
        public Deliveryman Deliveryman { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
        public int IdCompanyBranch { get; set; }
        public CompanyBranch CompanyBranch { get; set; }
        public double Distance { get; set; }
        public double DeliveryTime { get; set; }
    }
}