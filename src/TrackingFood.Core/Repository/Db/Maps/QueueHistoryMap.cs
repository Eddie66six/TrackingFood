using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingFood.Core.Domain.Entities;

namespace TrackingFood.Core.Repository.Db.Maps
{
    public class QueueHistoryMap : IEntityTypeConfiguration<QueueHistory>
    {
        public void Configure(EntityTypeBuilder<QueueHistory> builder)
        {
            builder.HasKey(p => p.IdQueueHistory);
        }
    }
}