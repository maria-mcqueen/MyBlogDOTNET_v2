using MediatR;
using MyBlog.Application.DTO;
using MyBlog.Domain.Aggregates.HabitAggregate.Repository;

namespace MyBlog.Application.Queries.Habit;

public sealed class GetAllHabitsByTypeHandler
    : IRequestHandler<GetAllHabitsByTypeQuery, IReadOnlyList<HabitLogDTO>>
{
    private readonly IHabitRepository _habitRepository;

    public GetAllHabitsByTypeHandler(IHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }

    public async Task<IReadOnlyList<HabitLogDTO>> Handle(
        GetAllHabitsByTypeQuery request,
        CancellationToken cancellationToken)
    {
        var habits = await _habitRepository.GetByHabitTypeAsync(request.HabitType, cancellationToken);

        return habits.Select(h => new HabitLogDTO(
            h.Id, h.HabitType, h.Date, h.IsCompleted))
            .ToList();
    }
}