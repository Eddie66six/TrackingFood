using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class CompanyBranch
    {
        public int IdCompanyBranch { get; set; }
        public string Name { get; set; }
        public int IdCompany { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Queue> Queues { get; set; }
        public IEnumerable<QueueHistory> QueueHistories { get; set; }
    }
}