namespace TrackingFood.Core.Domain.ViewModel
{
    public class SearchCompanyBranchViewModel
    {
        public int IdCompanyBranch { get; set; }
        public string NameCompanyBranch { get; set; }
        public double? MaxkilometersDelivery { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double  Distance { get; set; }
    }
}