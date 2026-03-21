using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Aggregates.PhotoAggregate;

namespace MyBlog.Infrastructure.Persistence.Configurations;

public class PhotoConfiguration:IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.FilePath)
            .IsRequired();

        builder.Property(x => x.UploadedAt)
            .IsRequired();

        builder.ToTable("Photos");
    }
}