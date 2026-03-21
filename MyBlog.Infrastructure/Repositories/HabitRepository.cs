using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Aggregates.HabitAggregate;
using MyBlog.Domain.Aggregates.HabitAggregate.Repository;
using MyBlog.Infrastructure.Persistence;

namespace MyBlog.Infrastructure.Repositories;

public class HabitRepository : IHabitRepository
{
    private readonly AppDbContext _context;

    public HabitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HabitLog?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.HabitLogs.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<HabitLog>> GetByHabitTypeAsync(string habitType, CancellationToken cancellationToken = default)
        => await _context.HabitLogs
            .Where(x => x.HabitType == habitType)
            .OrderBy(x => x.Date)
            .ToListAsync(cancellationToken);

    public async Task<HabitLog?> GetByDateAndTypeAsync(DateOnly date, string habitType, CancellationToken cancellationToken = default)
        => await _context.HabitLogs
            .FirstOrDefaultAsync(x => x.Date == date && x.HabitType == habitType, cancellationToken);

    public async Task AddAsync(HabitLog habitLog, CancellationToken cancellationToken = default)
    {
        await _context.HabitLogs.AddAsync(habitLog, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(HabitLog habitLog, CancellationToken cancellationToken = default)
    {
        _context.HabitLogs.Update(habitLog);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(HabitLog habitLog, CancellationToken cancellationToken = default)
    {
        _context.HabitLogs.Remove(habitLog);
        await _context.SaveChangesAsync(cancellationToken);
    }
}