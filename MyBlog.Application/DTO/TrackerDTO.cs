namespace MyBlog.Application.DTO;

public record TrackerActivityDTO(
    Guid Id,
    string Name,
    bool IsCompleted,
    DateTime CreatedAt
);