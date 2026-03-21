namespace MyBlog.Domain.Aggregates.HabitAggregate.Repository;

public interface IHabitRepository
{
    Task<HabitLog?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<HabitLog>> GetByHabitTypeAsync(string habitType, CancellationToken cancellationToken = default);
    Task<HabitLog?> GetByDateAndTypeAsync(DateOnly date, string habitType, CancellationToken cancellationToken = default);
    Task AddAsync(HabitLog habitLog, CancellationToken cancellationToken = default);
    Task UpdateAsync(HabitLog habitLog, CancellationToken cancellationToken = default);
    Task DeleteAsync(HabitLog habitLog, CancellationToken cancellationToken = default);
}
