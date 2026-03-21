using MediatR;
using MyBlog.Domain.Aggregates.PhotoAggregate;
using MyBlog.Domain.Aggregates.PhotoAggregate.Repository;

namespace MyBlog.Application.Commands.Photos;

public sealed class AddPhotoHandler : IRequestHandler<AddPhotoCommand, Guid>
{
    private readonly IPhotoRepository _photoRepository;

    public AddPhotoHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<Guid> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
    {
        var photo = Photo.Create(request.Title, request.Description, request.FilePath);
        await _photoRepository.AddAsync(photo, cancellationToken);
        return photo.Id;
    }
}