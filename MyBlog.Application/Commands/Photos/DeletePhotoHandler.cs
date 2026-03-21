using MediatR;
using MyBlog.Domain.Aggregates.PhotoAggregate.Repository;

namespace MyBlog.Application.Commands.Photos;

public sealed class DeletePhotoHandler : IRequestHandler<DeletePhotoCommand>
{
    private readonly IPhotoRepository _photoRepository;

    public DeletePhotoHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
    {
        var photo = await _photoRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Photo {request.Id} not found.");

        await _photoRepository.DeleteAsync(photo, cancellationToken);
    }
}