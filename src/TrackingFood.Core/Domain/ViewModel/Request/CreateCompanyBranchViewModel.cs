namespace TrackingFood.Core.Domain.ViewModel.Request
{
    public class CreateCompanyBranchViewModel
    {
        public string Name { get; set; }
        public int IdCompany { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}