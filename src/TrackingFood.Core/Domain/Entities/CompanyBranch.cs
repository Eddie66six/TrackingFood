using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class CompanyBranch : Entity
    {
        private CompanyBranch()
        {
            
        }
        public CompanyBranch(string name, int idCompany, string latitude, string longitude)
        {
            Name = name;
            IdCompany = idCompany;
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }
        public CompanyBranch(string name, Company company, string latitude, string longitude)
        {
            Name = name;
            Company = company;
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name) || (IdCompany <= 0 && Company == null) || string.IsNullOrEmpty(Latitude) || string.IsNullOrEmpty(Longitude))
                AddError("Invalid Company branch");
        }
        public int IdCompanyBranch { get; set; }
        public string Name { get; set; }
        public int IdCompany { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Queue> Queues { get; set; }
        public IEnumerable<QueueHistory> QueueHistories { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public IEnumerable<Deliveryman> CurrentDeliverymens { get; set; }
    }
}