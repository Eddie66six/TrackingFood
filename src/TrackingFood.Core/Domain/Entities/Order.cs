using System.Collections;
using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Order : Entity
    {
        public int IdOrder { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal DeliveryValue { get; set; }
        public int IdCompanyBranch { get; set; }
        public CompanyBranch CompanyBranch { get; set; }
        public Queue Queue { get; set; }
        public QueueHistory QueueHistory { get; set; }
    }
}