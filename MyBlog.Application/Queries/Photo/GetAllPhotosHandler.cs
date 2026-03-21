using MediatR;
using MyBlog.Application.DTO;
using MyBlog.Domain.Aggregates.PhotoAggregate.Repository;

namespace MyBlog.Application.Queries.Photo;

public sealed class GetAllPhotosHandler
    : IRequestHandler<GetAllPhotosQuery, IReadOnlyList<PhotoDTO>>
{
    private readonly IPhotoRepository _photoRepository;

    public GetAllPhotosHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<IReadOnlyList<PhotoDTO>> Handle(
        GetAllPhotosQuery request,
        CancellationToken cancellationToken)
    {
        var photos = await _photoRepository.GetAllAsync(cancellationToken);

        return photos.Select(p => new PhotoDTO(
            p.Id, p.Title, p.Description, p.FilePath, p.UploadedAt))
            .ToList();
    }
}