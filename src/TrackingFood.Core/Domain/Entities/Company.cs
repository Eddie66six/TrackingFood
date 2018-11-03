using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Company : Entity
    {
        private Company()
        {
            CompanyBranches = new List<CompanyBranch>();
        }

        public Company(string name)
        {
            Name = name;
            Validate();
        }
        public Company(string name, CompanyBranch companyBranch)
        {
            Name = name;
            CompanyBranches = new List<CompanyBranch> { companyBranch };
            Validate();
        }
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddError("Invalid company");
        }
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public IEnumerable<CompanyBranch> CompanyBranches { get; set; }
    }
}