namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Employee : Entity
    {
        private Employee()
        {
            
        }

        public Employee(string name, int idCompanyBranch)
        {
            Name = name;
            IdCompanyBranch = idCompanyBranch;
            Validate();
        }
        public Employee(string name, CompanyBranch companyBranch)
        {
            Name = name;
            CompanyBranch = companyBranch;
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name) || (IdCompanyBranch <= 0 && CompanyBranch == null))
                AddError("Invalid employee");
        }

        public int IdEmployee { get; private set; }
        public string Name { get; private set; }
        public int IdCompanyBranch { get; private set; }
        public CompanyBranch CompanyBranch { get; private set; }
        public int IdCredencial { get; private set; }
        public Credencial Credencial { get; private set; }
    }
}