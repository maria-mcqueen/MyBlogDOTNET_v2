namespace MyBlog.Domain.Aggregates.JournalAggregate.Repositories;

public interface IJournalRepository
{
    Task<JournalEntry?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<JournalEntry>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(JournalEntry journalEntry, CancellationToken cancellationToken = default);
    Task UpdateAsync(JournalEntry journalEntry, CancellationToken cancellationToken = default);
    Task DeleteAsync(JournalEntry journalEntry, CancellationToken cancellationToken = default);
}
