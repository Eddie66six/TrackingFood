using System.Collections.Generic;

namespace TrackingFood.Core.Domain.ViewModel.Request
{
    public class CreateOrderViewModel
    {
        public int IdCustomer { get; set; }
        public int IdDeliveryAddress { get; set; }
        public int IdCompanyBranch { get; set; }
        public decimal DeliveryValue { get; set; }
        public List<CreateOrderItemViewModel> Items { get; set; }
    }

    public class CreateOrderItemViewModel
    {
        public int IdMenuItem { get; set; }
        public int Amount { get; set; }
    }
}