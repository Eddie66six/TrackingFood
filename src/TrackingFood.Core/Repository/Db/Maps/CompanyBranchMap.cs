using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class CompanyBranchMap : IEntityTypeConfiguration<CompanyBranch>
    {
        public void Configure(EntityTypeBuilder<CompanyBranch> builder)
        {
            builder.HasKey(p => p.IdCompanyBranch);
            builder.Property(p => p.Name).HasMaxLength(200);

            builder.HasMany(p => p.Menus)
                .WithOne(p => p.CompanyBranch)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Orders)
                .WithOne(p => p.CompanyBranch)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Queues)
                .WithOne(p => p.CompanyBranch)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.QueueHistories)
                .WithOne(p => p.CompanyBranch)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Employees)
                .WithOne(p => p.CompanyBranch)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.CurrentDeliverymens)
                .WithOne(p => p.CurrentCompanyBranch)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}