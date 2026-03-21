using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Domain.Aggregates.HabitAggregate.Repository;
using MyBlog.Domain.Aggregates.HighlightAggregate.Repository;
using MyBlog.Domain.Aggregates.JournalAggregate.Repositories;
using MyBlog.Domain.Aggregates.PhotoAggregate.Repository;
using MyBlog.Domain.Aggregates.TrackerAggregate.Repository;
using MyBlog.Infrastructure.Persistence;
using MyBlog.Infrastructure.Repositories;

namespace MyBlog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IJournalRepository, JournalRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IHighlightRepository, HighlightRepository>();
        services.AddScoped<ITrackerRepository, TrackerRepository>();
        services.AddScoped<IHabitRepository, HabitRepository>();

        return services;
    }
}