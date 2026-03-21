namespace MyBlog.Application.DTO;

public record PhotoDTO(
    Guid Id,
    string Title,
    string Description,
    string FilePath,
    DateTime UploadedAt
);