using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Company
    {
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public IEnumerable<CompanyBranch> CompanyBranches { get; set; }
    }
}