using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(p => p.IdCompany);
            builder.Property(p => p.Name).HasMaxLength(200);

            builder.HasMany(p => p.CompanyBranches)
                .WithOne(p => p.Company);
        }
    }
}