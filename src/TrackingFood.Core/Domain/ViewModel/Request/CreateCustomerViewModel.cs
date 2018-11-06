namespace TrackingFood.Core.Domain.ViewModel.Request
{
    public class CreateCustomerViewModel
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        //credencial
        public string Email { get; set; }
        public string Password { get; set; }
        //address
        public string City { get; set; }
        public string Address { get; set; }
        public string FullNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}