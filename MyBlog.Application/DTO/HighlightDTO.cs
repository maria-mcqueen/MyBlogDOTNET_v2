namespace MyBlog.Application.DTO;

public record HighlightDTO(
    Guid Id,
    string Title,
    string Game,
    string? FilePath,
    string? YouTubeUrl,
    DateTime UploadedAt
);