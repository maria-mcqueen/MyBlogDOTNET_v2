using MediatR;
using MyBlog.Application.DTO;
using MyBlog.Domain.Aggregates.HighlightAggregate.Repository;

namespace MyBlog.Application.Queries.Highlight;

public sealed class GetAllHighlightsHandler
    : IRequestHandler<GetAllHighlightsQuery, IReadOnlyList<HighlightDTO>>
{
    private readonly IHighlightRepository _highlightRepository;

    public GetAllHighlightsHandler(IHighlightRepository highlightRepository)
    {
        _highlightRepository = highlightRepository;
    }

    public async Task<IReadOnlyList<HighlightDTO>> Handle(
        GetAllHighlightsQuery request,
        CancellationToken cancellationToken)
    {
        var highlights = request.Game is not null
            ? await _highlightRepository.GetByGameAsync(request.Game, cancellationToken)
            : await _highlightRepository.GetAllAsync(cancellationToken);

        return highlights.Select(h => new HighlightDTO(
            h.Id, h.Title, h.Game, h.FilePath, h.YouTubeUrl, h.UploadedAt))
            .ToList();
    }
}