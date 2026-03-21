using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Aggregates.JournalAggregate;
using MyBlog.Domain.Aggregates.JournalAggregate.Repositories;
using MyBlog.Infrastructure.Persistence;

namespace MyBlog.Infrastructure.Repositories;

public class JournalRepository : IJournalRepository
{
    private readonly AppDbContext _context;

    public JournalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<JournalEntry?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.JournalEntries.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<JournalEntry>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.JournalEntries.OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);

    public async Task AddAsync(JournalEntry journalEntry, CancellationToken cancellationToken = default)
    {
        await _context.JournalEntries.AddAsync(journalEntry, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(JournalEntry journalEntry, CancellationToken cancellationToken = default)
    {
        _context.JournalEntries.Update(journalEntry);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(JournalEntry journalEntry, CancellationToken cancellationToken = default)
    {
        _context.JournalEntries.Remove(journalEntry);
        await _context.SaveChangesAsync(cancellationToken);
    }
}