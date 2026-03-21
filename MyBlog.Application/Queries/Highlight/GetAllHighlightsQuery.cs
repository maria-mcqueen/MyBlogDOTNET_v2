using MediatR;
using MyBlog.Application.DTO;


namespace MyBlog.Application.Queries.Highlight;

public record GetAllHighlightsQuery(string? Game = null) : IRequest<IReadOnlyList<HighlightDTO>>;