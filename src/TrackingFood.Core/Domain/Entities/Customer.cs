using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Customer : Entity
    {
        private Customer()
        {
            
        }
        public Customer(string name, string documentNumber, DeliveryAddress deliveryAddress, Credencial credencial)
        {
            Name = name;
            DocumentNumber = Regex.Replace(documentNumber ?? "", @"[^0-9]", "");
            Adresses = new List<DeliveryAddress> { deliveryAddress };
            Credencial = credencial;
            Validate();
        }

        public void Update(string name, string documentNumber)
        {
            Name = name;
            DocumentNumber = Regex.Replace(documentNumber ?? "", @"[^0-9]", "");
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name) || Name.Length < 3)
                AddError("Invalid name");
            if (Adresses == null)
                AddError("Invalid Address");
            if (string.IsNullOrEmpty(DocumentNumber) || DocumentNumber.Length < 11)
                AddError("Invalid Document number");
            if (Credencial == null)
                AddError("Invalid credencial");
        }

        public void AddAdress(DeliveryAddress deliveryAddress)
        {
            Adresses.Add(deliveryAddress);
        }

        public int IdCustomer { get; private set; }
        public string Name { get; private set; }
        public string DocumentNumber { get; private set; }
        public List<DeliveryAddress> Adresses { get; private set; }
        public int IdCredencial { get; private set; }
        public Credencial Credencial { get; private set; }
        public List<Order> orders { get; private set; }
    }
}