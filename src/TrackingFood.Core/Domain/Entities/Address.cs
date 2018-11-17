using System;
using System.Globalization;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Address : Entity
    {
        private Address()
        {

        }
        public Address(string city, string addressDescription, string fullNumber, double latitude, double longitude)
        {
            City = city;
            AddressDescription = addressDescription;
            FullNumber = fullNumber;
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }

        public void Update(string city, string addressDescription, string fullNumber, double latitude, double longitude)
        {
            City = city;
            AddressDescription = addressDescription;
            FullNumber = fullNumber;
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(City) || string.IsNullOrEmpty(AddressDescription) || string.IsNullOrEmpty(FullNumber)
                || Latitude.ToString(CultureInfo.InvariantCulture).Length < 5 || Longitude.ToString(CultureInfo.InvariantCulture).Length < 5)
                AddError("Invalid Address");
        }

        public int IdAddress { get; set; }
        public string City { get; private set; }
        public string AddressDescription { get; private set; }
        public string FullNumber { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public CompanyBranch CompanyBranch { get; private set; }
    }
}
