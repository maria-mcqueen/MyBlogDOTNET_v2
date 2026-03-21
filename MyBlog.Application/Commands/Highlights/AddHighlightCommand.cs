using MediatR;

namespace MyBlog.Application.Commands.Highlights;

public record AddHighlightCommand(
    string Title,
    string Game,
    string? FilePath,
    string? YouTubeUrl) : IRequest<Guid>;