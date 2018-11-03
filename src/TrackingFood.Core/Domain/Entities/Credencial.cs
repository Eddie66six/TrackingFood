namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Credencial : Entity
    {
        private Credencial()
        {

        }
        public Credencial(string email, string password)
        {
            Email = email;
            Password = password;
            Validate();
        }


        public void Update(string password)
        {
            Password = password;
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || Password.Length < 6)
                AddError("Invalid credencial");
            if ((!Email?.Contains('@') ?? false) || (!Email?.Contains('.') ?? false))
                AddError("Invalid email");
        }

        public int IdCredencial { get; set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Customer Customer { get; private set; }
        public Employee Employee { get; private set; }
    }
}