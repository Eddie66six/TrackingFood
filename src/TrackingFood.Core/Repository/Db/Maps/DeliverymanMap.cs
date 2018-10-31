using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class DeliverymanMap : IEntityTypeConfiguration<Deliveryman>
    {
        public void Configure(EntityTypeBuilder<Deliveryman> builder)
        {
            builder.HasKey(p => p.IdDeliveryman);
            builder.Property(p => p.Name).HasMaxLength(100);

            builder.HasMany(p => p.Queues)
                .WithOne(p => p.Deliveryman);
        }
    }
}