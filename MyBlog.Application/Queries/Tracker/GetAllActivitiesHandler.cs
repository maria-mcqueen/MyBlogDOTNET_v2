using MediatR;
using MyBlog.Application.DTO;
using MyBlog.Domain.Aggregates.TrackerAggregate.Repository;

namespace MyBlog.Application.Queries.Tracker;

public sealed class GetAllActivitiesHandler
    : IRequestHandler<GetAllActivitiesQuery, IReadOnlyList<TrackerActivityDTO>>
{
    private readonly ITrackerRepository _trackerRepository;

    public GetAllActivitiesHandler(ITrackerRepository trackerRepository)
    {
        _trackerRepository = trackerRepository;
    }

    public async Task<IReadOnlyList<TrackerActivityDTO>> Handle(
        GetAllActivitiesQuery request,
        CancellationToken cancellationToken)
    {
        var activities = await _trackerRepository.GetAllAsync(cancellationToken);

        return activities.Select(a => new TrackerActivityDTO(
            a.Id, a.Name, a.IsCompleted, a.CreatedAt))
            .ToList();
    }
}