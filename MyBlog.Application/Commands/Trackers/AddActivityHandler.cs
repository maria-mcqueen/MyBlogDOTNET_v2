using MediatR;
using MyBlog.Domain.Aggregates.TrackerAggregate;
using MyBlog.Domain.Aggregates.TrackerAggregate.Repository;

namespace MyBlog.Application.Commands.Tracker;

public sealed class AddActivityHandler : IRequestHandler<AddActivityCommand, Guid>
{
    private readonly ITrackerRepository _trackerRepository;

    public AddActivityHandler(ITrackerRepository trackerRepository)
    {
        _trackerRepository = trackerRepository;
    }

    public async Task<Guid> Handle(AddActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = TrackerActivity.Create(request.Name);
        await _trackerRepository.AddAsync(activity, cancellationToken);
        return activity.Id;
    }
}