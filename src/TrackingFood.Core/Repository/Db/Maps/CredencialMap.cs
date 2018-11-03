using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class CredencialMap : IEntityTypeConfiguration<Credencial>
    {
        public void Configure(EntityTypeBuilder<Credencial> builder)
        {
            builder.HasKey(p => p.IdCredencial);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.Password).HasMaxLength(21);
        }
    }
}