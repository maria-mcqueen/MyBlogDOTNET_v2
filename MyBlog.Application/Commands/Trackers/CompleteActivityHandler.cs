using MediatR;
using MyBlog.Domain.Aggregates.TrackerAggregate.Repository;

namespace MyBlog.Application.Commands.Tracker;

public sealed class CompleteActivityHandler : IRequestHandler<CompleteActivityCommand>
{
    private readonly ITrackerRepository _trackerRepository;

    public CompleteActivityHandler(ITrackerRepository trackerRepository)
    {
        _trackerRepository = trackerRepository;
    }

    public async Task Handle(CompleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _trackerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Activity {request.Id} not found.");

        activity.Complete();
        await _trackerRepository.UpdateAsync(activity, cancellationToken);
    }
}