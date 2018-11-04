using System.Collections.Generic;

namespace TrackingFood.Core.Domain.ViewModel.Request
{
    public class ForwardToDeDeliveryman
    {
        public int IdDeliveryman { get; set; }
        public List<ForwardToDeDeliverymanItem> Items { get; set; }
    }

    public class ForwardToDeDeliverymanItem
    {
        public int IdQueue { get; set; }
        public int Position { get; set; }
    }
}