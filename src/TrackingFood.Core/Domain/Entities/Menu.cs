using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Menu : Entity
    {
        private Menu()
        {
            
        }
        public Menu(string name)
        {
            Validate();
        }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
        public int IdMenu { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public int IdCompanyBranch { get; set; }
        public CompanyBranch CompanyBranch { get; set; }
    }
}