namespace TrackingFood.Core.Domain.ViewModel.Request
{
    public class CreateMenuItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public decimal Value { get; set; }
        public int IdMenu { get; set; }
    }
}