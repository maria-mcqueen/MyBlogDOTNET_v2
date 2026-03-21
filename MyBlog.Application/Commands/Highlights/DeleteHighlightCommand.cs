using MediatR;

namespace MyBlog.Application.Commands.Highlights;

public record DeleteHighlightCommand(Guid Id) : IRequest;