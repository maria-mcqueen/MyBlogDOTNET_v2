using MediatR;
using MyBlog.Application.DTO;
using MyBlog.Domain.Aggregates.JournalAggregate.Repositories;

namespace MyBlog.Application.Queries.Journal;

public sealed class GetAllJournalEntriesHandler
    : IRequestHandler<GetAllJournalEntriesQuery, IReadOnlyList<JournalEntryDTO>>
{
    private readonly IJournalRepository _journalRepository;

    public GetAllJournalEntriesHandler(IJournalRepository journalRepository)
    {
        _journalRepository = journalRepository;
    }

    public async Task<IReadOnlyList<JournalEntryDTO>> Handle(
        GetAllJournalEntriesQuery request,
        CancellationToken cancellationToken)
    {
        var entries = await _journalRepository.GetAllAsync(cancellationToken);

        return entries.Select(e => new JournalEntryDTO(
            e.Id, e.Title, e.Content, e.CreatedAt))
            .ToList();
    }
}