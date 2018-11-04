using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class MenuItemMap : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(p => p.IdMenuItens);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.UrlImage).HasMaxLength(1000);

            builder.HasMany(p => p.OrderItems)
                .WithOne(p => p.MenuItem)
                .HasForeignKey(p=> p.IdMenuItem);
        }
    }
}