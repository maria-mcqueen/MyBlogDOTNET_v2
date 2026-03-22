using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Commands.Highlights;
using MyBlog.Application.Queries.Highlight;

namespace MyBlog.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HighlightController : ControllerBase
{
    private readonly IMediator _mediator;

    public HighlightController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? game,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllHighlightsQuery(game), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] AddHighlightCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteHighlightCommand(id), cancellationToken);
        return NoContent();
    }
}