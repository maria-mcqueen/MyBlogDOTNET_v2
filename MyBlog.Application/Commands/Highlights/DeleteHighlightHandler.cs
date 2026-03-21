using MediatR;
using MyBlog.Domain.Aggregates.HighlightAggregate.Repository;

namespace MyBlog.Application.Commands.Highlights;

public sealed class DeleteHighlightHandler : IRequestHandler<DeleteHighlightCommand>
{
    private readonly IHighlightRepository _highlightRepository;

    public DeleteHighlightHandler(IHighlightRepository highlightRepository)
    {
        _highlightRepository = highlightRepository;
    }

    public async Task Handle(DeleteHighlightCommand request, CancellationToken cancellationToken)
    {
        var highlight = await _highlightRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Highlight {request.Id} not found.");

        await _highlightRepository.DeleteAsync(highlight, cancellationToken);
    }
}