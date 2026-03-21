using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Aggregates.PhotoAggregate;
using MyBlog.Domain.Aggregates.PhotoAggregate.Repository;
using MyBlog.Infrastructure.Persistence;

namespace MyBlog.Infrastructure.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly AppDbContext _context;

    public PhotoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Photo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Photos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Photo>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Photos.OrderByDescending(x => x.UploadedAt).ToListAsync(cancellationToken);

    public async Task AddAsync(Photo photo, CancellationToken cancellationToken = default)
    {
        await _context.Photos.AddAsync(photo, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Photo photo, CancellationToken cancellationToken = default)
    {
        _context.Photos.Remove(photo);
        await _context.SaveChangesAsync(cancellationToken);
    }
}