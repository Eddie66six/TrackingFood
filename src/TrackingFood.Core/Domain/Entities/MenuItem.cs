﻿using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class MenuItem : Entity
    {
        private MenuItem()
        {
            
        }
        public MenuItem(string name)
        {
            Validate();
        }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }

        public int IdMenuItens { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public decimal Value { get; set; }
        public int IdMenu { get; set; }
        public Menu Menu { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}