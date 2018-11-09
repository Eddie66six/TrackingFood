namespace TrackingFood.Core.Domain.ViewModel.Request
{
    public class CreateCompanyBranchViewModel
    {
        public string Name { get; set; }
        public int IdCompany { get; set; }
        //address
        public string City { get; set; }
        public string Address { get; set; }
        public string FullNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}