using MediatR;
using MyBlog.Application.DTO;

namespace MyBlog.Application.Queries.Tracker;

public record GetAllActivitiesQuery : IRequest<IReadOnlyList<TrackerActivityDTO>>;