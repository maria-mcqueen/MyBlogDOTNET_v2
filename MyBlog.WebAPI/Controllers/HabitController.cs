using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Commands.HabitLogs;
using MyBlog.Application.Queries.Habit;

namespace MyBlog.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitController : ControllerBase
{
    private readonly IMediator _mediator;

    public HabitController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{habitType}")]
    public async Task<IActionResult> GetByType(
        string habitType,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllHabitsByTypeQuery(habitType), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Log(
        [FromBody] HabitLogCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetByType), new { id });
    }

    [HttpPatch("{id:guid}/undo")]
    public async Task<IActionResult> Undo(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UndoHabitCommand(id), cancellationToken);
        return NoContent();
    }
}