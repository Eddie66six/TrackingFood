using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class DeliveryAddressMap : IEntityTypeConfiguration<DeliveryAddress>
    {
        public void Configure(EntityTypeBuilder<DeliveryAddress> builder)
        {
            builder.HasKey(p => p.IdDeliveryAddress);
            builder.Property(p => p.Name).HasMaxLength(200);

            builder.HasMany(p => p.Queues)
                .WithOne(p => p.DeliveryAddress);
        }
    }
}