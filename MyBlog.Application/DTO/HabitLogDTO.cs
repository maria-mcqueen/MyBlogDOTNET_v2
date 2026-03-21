namespace MyBlog.Application.DTO;

public record HabitLogDTO(
    Guid Id,
    string HabitType,
    DateOnly Date,
    bool IsCompleted
);