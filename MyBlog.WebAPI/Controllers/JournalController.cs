using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Commands.Journal;
using MyBlog.Application.Queries.Journal;

namespace MyBlog.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JournalController : ControllerBase 
{
    private readonly IMediator _mediator;

    public JournalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllJournalEntriesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] AddJournalEntryCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteJournalEntryCommand(id), cancellationToken);
        return NoContent();
    }
}

