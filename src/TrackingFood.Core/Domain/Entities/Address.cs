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

        public double CalculateDistence(double latitude, double longitude)
        {
            var R = 6371.0;          // R is earth radius.
            var dLat = ToRadian(latitude - Latitude);
            var dLon = ToRadian(longitude - Longitude);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadian(Latitude)) * Math.Cos(ToRadian(latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            var d = R * c;

            return d;
        }

        private double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
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
