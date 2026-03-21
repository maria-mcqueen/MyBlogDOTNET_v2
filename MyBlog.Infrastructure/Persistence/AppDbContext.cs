using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Aggregates.HabitAggregate;
using MyBlog.Domain.Aggregates.HighlightAggregate;
using MyBlog.Domain.Aggregates.JournalAggregate;
using MyBlog.Domain.Aggregates.PhotoAggregate;
using MyBlog.Domain.Aggregates.TrackerAggregate;
using System.Reflection;

namespace MyBlog.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<HabitLog> HabitLogs { get; set; }
    public DbSet<Highlight> Highlights { get; set; }
    public DbSet<JournalEntry> JournalEntries { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<TrackerActivity> TrackerActivities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
