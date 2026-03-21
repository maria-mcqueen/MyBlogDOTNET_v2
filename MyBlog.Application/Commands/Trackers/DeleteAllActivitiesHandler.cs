using MediatR;
using MyBlog.Domain.Aggregates.TrackerAggregate.Repository;

namespace MyBlog.Application.Commands.Tracker;

public sealed class DeleteAllActivitiesHandler : IRequestHandler<DeleteAllActivitiesCommand>
{
    private readonly ITrackerRepository _trackerRepository;

    public DeleteAllActivitiesHandler(ITrackerRepository trackerRepository)
    {
        _trackerRepository = trackerRepository;
    }

    public async Task Handle(DeleteAllActivitiesCommand request, CancellationToken cancellationToken)
    {
        await _trackerRepository.DeleteAllAsync(cancellationToken);
    }
}