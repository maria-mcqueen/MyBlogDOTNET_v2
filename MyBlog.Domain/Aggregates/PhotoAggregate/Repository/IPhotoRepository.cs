namespace MyBlog.Domain.Aggregates.PhotoAggregate.Repository;

public interface IPhotoRepository
{
    Task<Photo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Photo>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Photo photo, CancellationToken cancellationToken = default);
    Task DeleteAsync(Photo photo, CancellationToken cancellationToken = default);
}
