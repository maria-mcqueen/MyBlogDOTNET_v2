using MediatR;
using MyBlog.Domain.Aggregates.HabitAggregate;
using MyBlog.Domain.Aggregates.HabitAggregate.Repository;

namespace MyBlog.Application.Commands.HabitLogs;

public sealed class HabitLogHandler : IRequestHandler<HabitLogCommand, Guid>
{
    private readonly IHabitRepository _habitRepository;

    public HabitLogHandler(IHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }

    public async Task<Guid> Handle(HabitLogCommand request, CancellationToken cancellationToken)
    {
        var habit = HabitLog.Create(request.HabitType, request.Date);
        await _habitRepository.AddAsync(habit, cancellationToken);
        return habit.Id;
    }
}