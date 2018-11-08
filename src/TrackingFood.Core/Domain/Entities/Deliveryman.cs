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
            Name = name;
            Validate();
        }
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddError("Invalid deliveryman");
        }

        public void SetCurrentCompanyBranch(int idCompanyBranch)
        {
            IdCurrentCompanyBranch = idCompanyBranch;
        }

        public int IdDeliveryman { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Queue> Queues { get; private set; }
        public int? IdCurrentCompanyBranch { get; private set; }
        public CompanyBranch CurrentCompanyBranch { get; private set; }
    }
}