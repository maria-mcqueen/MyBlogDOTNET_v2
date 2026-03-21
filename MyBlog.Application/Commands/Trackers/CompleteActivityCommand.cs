using MediatR;

namespace MyBlog.Application.Commands.Tracker;

public record CompleteActivityCommand(Guid Id) : IRequest;