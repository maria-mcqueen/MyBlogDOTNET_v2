using MediatR;
using MyBlog.Application.DTO;

namespace MyBlog.Application.Queries.Journal;

public record GetAllJournalEntriesQuery : IRequest<IReadOnlyList<JournalEntryDTO>>;