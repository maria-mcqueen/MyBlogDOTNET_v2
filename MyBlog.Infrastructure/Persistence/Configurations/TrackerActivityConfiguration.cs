using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Aggregates.TrackerAggregate;

namespace MyBlog.Infrastructure.Persistence.Configurations;

public class TrackerActivityConfiguration : IEntityTypeConfiguration<TrackerActivity>
{
    public void Configure(EntityTypeBuilder<TrackerActivity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.IsCompleted)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.ToTable("TrackerActivities");
    }
}