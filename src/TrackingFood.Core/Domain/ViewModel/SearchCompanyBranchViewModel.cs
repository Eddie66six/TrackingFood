namespace TrackingFood.Core.Domain.ViewModel
{
    public class SearchCompanyBranchViewModel
    {
        public int IdCompanyBranch { get; set; }
        public string Name { get; set; }
        public double? MaxkilometersDelivery { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}