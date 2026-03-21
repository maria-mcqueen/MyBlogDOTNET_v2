namespace MyBlog.Domain.Aggregates.HighlightAggregate;

public sealed class Highlight : BaseEntity, IAggregateRoot
{
    public string Title { get; private set; } = string.Empty;
    public string Game { get; private set; } = string.Empty;
    public string? FilePath { get; private set; }
    public string? YouTubeUrl { get; private set; }
    public DateTime UploadedAt { get; private set; }

    private Highlight() { }

    private Highlight(Guid id, string title, string game, string? filePath, string? youTubeUrl) : base(id)
    {
        Title = title;
        Game = game;
        FilePath = filePath;
        YouTubeUrl = youTubeUrl;
        UploadedAt = DateTime.UtcNow;
    }

    public static Highlight Create(string title, string game, string? filePath, string? youTubeUrl)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (string.IsNullOrWhiteSpace(game))
            throw new ArgumentException("Game cannot be empty.");

        if (string.IsNullOrWhiteSpace(filePath) && string.IsNullOrWhiteSpace(youTubeUrl))
            throw new ArgumentException("Either a file or a YouTube URL must be provided.");

        return new Highlight(Guid.NewGuid(), title, game, filePath, youTubeUrl);
    }
}