using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Order : Entity
    {
        private Order()
        {
            
        }
        public Order(List<OrderItem> orderItems, decimal deliveryValue, int idCompanyBranch, int idCustomer)
        {
            OrderItems = orderItems;
            DeliveryValue = deliveryValue;
            IdCompanyBranch = idCompanyBranch;
            IdCustomer = idCustomer;
            Date = DateTime.UtcNow;
            Validate();
        }
        public Order(List<OrderItem> orderItems, decimal deliveryValue, CompanyBranch companyBranch, int idCustomer)
        {
            OrderItems = orderItems;
            DeliveryValue = deliveryValue;
            CompanyBranch = companyBranch;
            IdCustomer = idCustomer;
            Date = DateTime.UtcNow;
            Validate();
        }
        protected override void Validate()
        {
            if (CompanyBranch == null && IdCompanyBranch <= 0)
                AddError("Invalid branch");
            if (OrderItems.Count == 0)
                AddError("Invalid item");
            if (IdCustomer <= 0)
                AddError("Invalid customer");
        }
        public decimal GetTotalValue()
        {
            return DeliveryValue + OrderItems.Sum(p => p.MenuItem.Value * p.Amount);
        }
        public int IdOrder { get; set; }
        public List<OrderItem> OrderItems { get; private set; }
        public decimal DeliveryValue { get; private set; }
        public DateTime Date { get; set; }
        public int IdCompanyBranch { get; private set; }
        public CompanyBranch CompanyBranch { get; private set; }
        public Queue Queue { get; private set; }
        public QueueHistory QueueHistory { get; private set; }
        public int IdCustomer { get; private set; }
        public Customer Customer { get; set; }
    }
}