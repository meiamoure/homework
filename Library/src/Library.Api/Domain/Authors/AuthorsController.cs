using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
using Library.Api.Domain.Authors.Request;
using Library.Application.Domain.Authors.Commands.CreateAuthor;
using Library.Application.Domain.Authors.Commands.DeleteAuthor;
using Library.Application.Domain.Authors.Commands.UpdateAuthor;
using Library.Application.Domain.Authors.Queries.GetAuthorDetails;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Authors;

[Route(Routes.Authors)]
public class AuthorsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAuthors(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAuthorsQuery(page, pageSize);
        var authors = await mediator.Send(query, cancellationToken);
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAuthorDetails(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAuthorsDetailsQuery(id);
        var author = await mediator.Send(query, cancellationToken);
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult> AddAuthor(
        [FromBody][Required] CreateAuthorRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateAuthorCommand(
            request.FirstName,
            request.LastName);
        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuthor(
        [FromRoute] Guid id,
        [FromBody][Required] UpdateAuthorRequest request, CancellationToken cancellationToken = default)
    {
        var command = new UpdateAuthorCommand(
            id,
            request.FirstName,
            request.LastName);
        await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeeleteAuthor(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteAuthorCommand(id);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }
}
