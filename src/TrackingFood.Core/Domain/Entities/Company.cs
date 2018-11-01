using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Company : Entity
    {
        private Company()
        {
            
        }

        public Company(string name)
        {
            Validate();
        }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public IEnumerable<CompanyBranch> CompanyBranches { get; set; }
    }
}