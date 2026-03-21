using MediatR;

namespace MyBlog.Application.Commands.HabitLogs;

public record UndoHabitCommand(Guid Id) : IRequest;