using MediatR;

namespace MyBlog.Application.Commands.HabitLogs;

public record HabitLogCommand(string HabitType, DateOnly Date) : IRequest<Guid>;