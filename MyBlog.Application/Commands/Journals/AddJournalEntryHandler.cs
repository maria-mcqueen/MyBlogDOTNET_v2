using MediatR;
using MyBlog.Domain.Aggregates.JournalAggregate;
using MyBlog.Domain.Aggregates.JournalAggregate.Repositories;

namespace MyBlog.Application.Commands.Journal;

public sealed class AddJournalEntryHandler : IRequestHandler<AddJournalEntryCommand, Guid>
{
    private readonly IJournalRepository _journalRepository;

    public AddJournalEntryHandler(IJournalRepository journalRepository)
    {
        _journalRepository = journalRepository;
    }

    public async Task<Guid> Handle(AddJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = JournalEntry.Create(request.Title, request.Content);
        await _journalRepository.AddAsync(entry, cancellationToken);
        return entry.Id;
    }
}