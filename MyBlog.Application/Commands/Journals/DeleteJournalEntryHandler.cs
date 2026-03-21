using MediatR;
using MyBlog.Domain.Aggregates.JournalAggregate.Repositories;

namespace MyBlog.Application.Commands.Journal;

public sealed class DeleteJournalEntryHandler : IRequestHandler<DeleteJournalEntryCommand>
{
    private readonly IJournalRepository _journalRepository;

    public DeleteJournalEntryHandler(IJournalRepository journalRepository)
    {
        _journalRepository = journalRepository;
    }

    public async Task Handle(DeleteJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await _journalRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Journal entry {request.Id} not found.");

        await _journalRepository.DeleteAsync(entry, cancellationToken);
    }
}