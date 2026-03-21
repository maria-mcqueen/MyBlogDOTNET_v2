using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Aggregates.HabitAggregate;

namespace MyBlog.Infrastructure.Persistence.Configurations;

public class HabitLogConfiguration : IEntityTypeConfiguration<HabitLog>
{
    public void Configure(EntityTypeBuilder<HabitLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.HabitType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Date)
            .IsRequired();

        builder.Property(x => x.IsCompleted)
            .IsRequired();

        builder.ToTable("HabitLogs");
    }
}