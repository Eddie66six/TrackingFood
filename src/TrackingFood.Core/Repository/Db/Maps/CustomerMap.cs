using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.IdCustomer);
            builder.Property(p => p.Name).HasMaxLength(50);

            builder.HasMany(p => p.Adresses)
                .WithOne(p => p.Customer);
            builder.HasMany(p => p.orders)
                .WithOne(p => p.Customer);

            builder.HasOne(p => p.Credencial);
        }
    }
}