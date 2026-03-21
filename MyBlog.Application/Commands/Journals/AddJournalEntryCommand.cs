using MediatR;

namespace MyBlog.Application.Commands.Journal;

public record AddJournalEntryCommand(string Title, string Content) : IRequest<Guid>;