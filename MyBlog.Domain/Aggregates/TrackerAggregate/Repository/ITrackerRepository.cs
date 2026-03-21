namespace MyBlog.Domain.Aggregates.TrackerAggregate.Repository;

public interface ITrackerRepository
{
    Task<TrackerActivity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TrackerActivity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(TrackerActivity activity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TrackerActivity activity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TrackerActivity activity, CancellationToken cancellationToken = default);
    Task DeleteAllAsync(CancellationToken cancellationToken = default);
}
