using MediatR;
using MyBlog.Domain.Aggregates.HighlightAggregate;
using MyBlog.Domain.Aggregates.HighlightAggregate.Repository;

namespace MyBlog.Application.Commands.Highlights;

public sealed class AddHighlightHandler : IRequestHandler<AddHighlightCommand, Guid>
{
    private readonly IHighlightRepository _highlightRepository;

    public AddHighlightHandler(IHighlightRepository highlightRepository)
    {
        _highlightRepository = highlightRepository;
    }

    public async Task<Guid> Handle(AddHighlightCommand request, CancellationToken cancellationToken)
    {
        var highlight = Highlight.Create(request.Title, request.Game, request.FilePath, request.YouTubeUrl);
        await _highlightRepository.AddAsync(highlight, cancellationToken);
        return highlight.Id;
    }
}