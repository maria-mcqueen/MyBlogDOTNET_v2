using MediatR;

namespace MyBlog.Application.Commands.Photos;

public record DeletePhotoCommand(Guid Id) : IRequest;