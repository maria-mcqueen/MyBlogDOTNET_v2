using MediatR;
using MyBlog.Application.DTO;

namespace MyBlog.Application.Queries.Photo;

public record GetAllPhotosQuery : IRequest<IReadOnlyList<PhotoDTO>>;