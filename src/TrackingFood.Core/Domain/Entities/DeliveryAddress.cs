using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class DeliveryAddress : Entity
    {
        private DeliveryAddress()
        {

        }
        public DeliveryAddress(string name, Address address)
        {
            Name = name;
            Address = address;
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name) || Address == null)
                AddError("Invalid Address");
        }


        public int IdDeliveryAddress { get; private set; }
        public string Name { get; private set; }
        public int IdAddress { get; set; }
        public Address Address { get; private set; }
        public int IdCustomer { get; private set; }
        public Customer Customer { get; private set; }
        public IEnumerable<Queue> Queues { get; private set; }
    }
}
