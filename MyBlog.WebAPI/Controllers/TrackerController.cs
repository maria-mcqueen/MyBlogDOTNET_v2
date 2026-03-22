using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Commands.Tracker;
using MyBlog.Application.Queries.Tracker;

namespace MyBlog.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrackerController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrackerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllActivitiesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] AddActivityCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id });
    }

    [HttpPatch("{id:guid}/complete")]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CompleteActivityCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpDelete("all")]
    public async Task<IActionResult> DeleteAll(CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteAllActivitiesCommand(), cancellationToken);
        return NoContent();
    }
}