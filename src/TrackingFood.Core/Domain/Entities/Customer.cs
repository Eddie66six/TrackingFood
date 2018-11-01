using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Customer : Entity
    {
        private Customer()
        {
            
        }
        public Customer(string name, DeliveryAddress deliveryAddress)
        {
            Name = name;
            Adresses = new List<DeliveryAddress> { deliveryAddress };
            Validate();
        }
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name) || Name.Length < 3)
                AddError("Invalid name");
            if (Adresses == null)
                AddError("Invalid Address");
        }

        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public List<DeliveryAddress> Adresses { get; set; }
    }
}