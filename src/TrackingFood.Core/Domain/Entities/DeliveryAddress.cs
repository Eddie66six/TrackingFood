using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class DeliveryAddress : Entity
    {
        private DeliveryAddress()
        {
            
        }
        public DeliveryAddress(string city, string address, string fullNumber, string latitude, string longitude)
        {
            City = city;
            Address = address;
            FullNumber = fullNumber;
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }

        public void Update(string city, string address, string fullNumber, string latitude, string longitude)
        {
            City = city;
            Address = address;
            FullNumber = fullNumber;
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(FullNumber)
                || string.IsNullOrEmpty(Latitude) || string.IsNullOrEmpty(Longitude))
                AddError("Invalid Address");
        }

        public int IdDeliveryAddress { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string FullNumber { get; private set; }
        public int IdCustomer { get; private set; }
        public Customer Customer { get; private set; }
        public IEnumerable<Queue> Queues { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
    }
}
