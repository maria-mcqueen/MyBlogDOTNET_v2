using MediatR;
using MyBlog.Application.DTO;

namespace MyBlog.Application.Queries.Habit;

public record GetAllHabitsByTypeQuery(string HabitType) : IRequest<IReadOnlyList<HabitLogDTO>>;