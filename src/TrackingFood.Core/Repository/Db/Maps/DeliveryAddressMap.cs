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
            builder.Property(p => p.Address).HasMaxLength(200);
            builder.Property(p => p.FullNumber).HasMaxLength(50);

            builder.HasMany(p => p.Queues)
                .WithOne(p => p.DeliveryAddress);
        }
    }
}