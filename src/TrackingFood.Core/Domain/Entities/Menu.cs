using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Menu : Entity
    {
        private Menu()
        {
            MenuItems = new List<MenuItem>();
        }
        public Menu(string name)
        {
            Name = name;
            MenuItems = new List<MenuItem>();
            Validate();
        }
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name) || (IdCompanyBranch <= 0 && CompanyBranch == null))
                AddError("Invalid menu");
        }
        public int IdMenu { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public int IdCompanyBranch { get; set; }
        public CompanyBranch CompanyBranch { get; set; }
    }
}