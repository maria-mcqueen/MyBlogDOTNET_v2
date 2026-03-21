
namespace MyBlog.Domain.Aggregates.HighlightAggregate.Repository;

public interface IHighlightRepository
{
    Task<Highlight?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Highlight>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Highlight>> GetByGameAsync(string game, CancellationToken cancellationToken = default);
    Task AddAsync(Highlight highlight, CancellationToken cancellationToken = default);
    Task DeleteAsync(Highlight highlight, CancellationToken cancellationToken = default);
}
