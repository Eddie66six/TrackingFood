using System.Collections.Generic;

namespace TrackingFood.Core.Domain.Entities
{
    public sealed class Menu : Entity
    {
        public int IdMenu { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}