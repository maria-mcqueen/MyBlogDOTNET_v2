using MediatR;

namespace MyBlog.Application.Commands.Tracker;

public record AddActivityCommand(string Name) : IRequest<Guid>;