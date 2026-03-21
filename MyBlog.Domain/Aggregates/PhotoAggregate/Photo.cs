
namespace MyBlog.Domain.Aggregates.PhotoAggregate;

public sealed class Photo : BaseEntity, IAggregateRoot
{
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string FilePath { get; private set; } = string.Empty;
    public DateTime UploadedAt { get; private set; }

    private Photo() { }
    private Photo(Guid id, string title, string description, string filePath) : base(id)
    {
        Title = title;
        Description = description;
        FilePath = filePath;
        UploadedAt = DateTime.UtcNow;
    }
    public static Photo Create(string title, string description, string filePath)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException("Title cannot be empty");
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException("File path cannot be empty");
        return new Photo(Guid.NewGuid(), title, description, filePath);
    }
}
