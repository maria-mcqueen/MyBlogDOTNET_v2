using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Aggregates.HighlightAggregate;

namespace MyBlog.Infrastructure.Persistence.Configurations;

public class HighlightConfiguration:IEntityTypeConfiguration<Highlight>
{
    public void Configure(EntityTypeBuilder<Highlight> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Game)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.FilePath);

        builder.Property(x => x.YouTubeUrl);

        builder.Property(x => x.UploadedAt)
            .IsRequired();

        builder.ToTable("Highlights");
    }
}
