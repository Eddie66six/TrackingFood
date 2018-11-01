using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class CompanyBranch : Entity
    {
        private CompanyBranch()
        {
            
        }

        public CompanyBranch(string name)
        {
            Validate();
        }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
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