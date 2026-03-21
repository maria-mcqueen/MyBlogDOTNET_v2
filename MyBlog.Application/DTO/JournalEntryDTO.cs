namespace MyBlog.Application.DTO;

public record JournalEntryDTO(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedAt
);