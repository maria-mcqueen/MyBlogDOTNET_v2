using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Aggregates.TrackerAggregate;
using MyBlog.Domain.Aggregates.TrackerAggregate.Repository;
using MyBlog.Infrastructure.Persistence;

namespace MyBlog.Infrastructure.Repositories;

public class TrackerRepository : ITrackerRepository
{
    private readonly AppDbContext _context;

    public TrackerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TrackerActivity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.TrackerActivities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<TrackerActivity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.TrackerActivities.OrderBy(x => x.CreatedAt).ToListAsync(cancellationToken);

    public async Task AddAsync(TrackerActivity activity, CancellationToken cancellationToken = default)
    {
        await _context.TrackerActivities.AddAsync(activity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TrackerActivity activity, CancellationToken cancellationToken = default)
    {
        _context.TrackerActivities.Update(activity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TrackerActivity activity, CancellationToken cancellationToken = default)
    {
        _context.TrackerActivities.Remove(activity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken = default)
    {
        var activities = await _context.TrackerActivities.ToListAsync(cancellationToken);
        _context.TrackerActivities.RemoveRange(activities);
        await _context.SaveChangesAsync(cancellationToken);
    }
}