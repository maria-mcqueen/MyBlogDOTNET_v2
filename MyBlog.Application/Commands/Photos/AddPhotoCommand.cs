using MediatR;

namespace MyBlog.Application.Commands.Photos;

public record AddPhotoCommand(string Title, string Description, string FilePath) : IRequest<Guid>;