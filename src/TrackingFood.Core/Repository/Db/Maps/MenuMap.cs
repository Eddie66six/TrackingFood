using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(p => p.IdMenu);

            builder.HasMany(p => p.MenuItems)
                .WithOne(p => p.Menu);
        }
    }
}