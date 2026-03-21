using MediatR;

namespace MyBlog.Application.Commands.Journal;

public record DeleteJournalEntryCommand(Guid Id) : IRequest;