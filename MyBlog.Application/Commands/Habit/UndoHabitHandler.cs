using MediatR;
using MyBlog.Domain.Aggregates.HabitAggregate.Repository;

namespace MyBlog.Application.Commands.HabitLogs;

public sealed class UndoHabitHandler : IRequestHandler<UndoHabitCommand>
{
    private readonly IHabitRepository _habitRepository;

    public UndoHabitHandler(IHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }

    public async Task Handle(UndoHabitCommand request, CancellationToken cancellationToken)
    {
        var habit = await _habitRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Habit log {request.Id} not found.");

        habit.Undo();
        await _habitRepository.UpdateAsync(habit, cancellationToken);
    }
}