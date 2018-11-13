using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class CompanyBranch : Entity
    {
        private CompanyBranch()
        {
            
        }
        public CompanyBranch(string name, int idCompany, double? maxkilometersDelivery, Address address)
        {
            Name = name;
            IdCompany = idCompany;
            Address = address;
            MaxkilometersDelivery = maxkilometersDelivery;
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name) || (IdCompany <= 0 && Company == null) || Address == null)
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
        public IEnumerable<Deliveryman> CurrentDeliverymens { get; set; }
        public int IdAddress { get; set; }
        public Address Address { get; private set; }
        public double? MaxkilometersDelivery { get; private set; }
    }
}