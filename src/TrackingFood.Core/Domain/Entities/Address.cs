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
                || Latitude == 0 || Longitude == 0)
                AddError("Invalid Address");
        }

        public void CalculateDistence(string latitude, string longitude)
        {
            //System.Device.Location
            //var sCoord = new GeoCoordinate(sLatitude, sLongitude);
            //var eCoord = new GeoCoordinate(eLatitude, eLongitude);

            //return sCoord.GetDistanceTo(eCoord);
        }

        public int IdAddress { get; set; }
        public string City { get; private set; }
        public string AddressDescription { get; private set; }
        public string FullNumber { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
    }
}
