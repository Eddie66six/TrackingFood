using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Deliveryman : Entity
    {
        private Deliveryman()
        {
            
        }
        public Deliveryman(string name)
        {
            Validate();
        }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
        public int IdDeliveryman { get; set; }
        public string Name { get; set; }
        public IEnumerable<Queue> Queues { get; set; }
        public int IdCurrentCompanyBranch { get; set; }
        public CompanyBranch CurrentCompanyBranch { get; set; }
    }
}