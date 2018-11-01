using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class DeliveryAddress : Entity
    {
        private DeliveryAddress()
        {
            
        }
        public DeliveryAddress(string city, string address, string fullNumber)
        {
            City = city;
            Address = address;
            FullNumber = fullNumber;
            Validate();
        }
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(FullNumber))
                AddError("Invalid Address");
        }

        public int IdDeliveryAddress { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string FullNumber { get; set; }
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Queue> Queues { get; set; }
    }
}
