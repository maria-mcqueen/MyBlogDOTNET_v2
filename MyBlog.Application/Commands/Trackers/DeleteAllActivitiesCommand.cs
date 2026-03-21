using MediatR;

namespace MyBlog.Application.Commands.Tracker;

public record DeleteAllActivitiesCommand : IRequest;