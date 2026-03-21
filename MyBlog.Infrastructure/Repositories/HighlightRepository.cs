using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Aggregates.HighlightAggregate;
using MyBlog.Domain.Aggregates.HighlightAggregate.Repository;
using MyBlog.Infrastructure.Persistence;

namespace MyBlog.Infrastructure.Repositories;

public class HighlightRepository : IHighlightRepository
{
    private readonly AppDbContext _context;

    public HighlightRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Highlight?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Highlights.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Highlight>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Highlights.OrderByDescending(x => x.UploadedAt).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Highlight>> GetByGameAsync(string game, CancellationToken cancellationToken = default)
        => await _context.Highlights
            .Where(x => x.Game == game)
            .OrderByDescending(x => x.UploadedAt)
            .ToListAsync(cancellationToken);

    public async Task AddAsync(Highlight highlight, CancellationToken cancellationToken = default)
    {
        await _context.Highlights.AddAsync(highlight, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Highlight highlight, CancellationToken cancellationToken = default)
    {
        _context.Highlights.Remove(highlight);
        await _context.SaveChangesAsync(cancellationToken);
    }
}