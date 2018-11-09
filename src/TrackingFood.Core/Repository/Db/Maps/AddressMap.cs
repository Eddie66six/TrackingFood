using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.IdAddress);
            builder.Property(p => p.FullNumber).HasMaxLength(50);

            builder.HasOne(p => p.DeliveryAddress)
                .WithOne(p => p.Address);
        }
    }
}
