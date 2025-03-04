using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
using Library.Api.Domain.Books.Records;
using Library.Application.Domain.Books.Commands.AssignAuthor;
using Library.Application.Domain.Books.Commands.CreateBook;
using Library.Application.Domain.Books.Commands.DeleteBook;
using Library.Application.Domain.Books.Commands.RemoveAuthor;
using Library.Application.Domain.Books.Commands.UpdateBook;
using Library.Application.Domain.Books.Queries.GetBookByName;
using Library.Application.Domain.Books.Queries.GetBookDetails;
using Library.Application.Domain.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Books;

[Route(Routes.Books)]
public class BooksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetBooks(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetBooksQuery(page, pageSize);
        var books = await mediator.Send(query, cancellationToken);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBook(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetBookDetailsQuery(id);
        var book = await mediator.Send(query, cancellationToken);
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult> AddBook(
        [FromBody][Required] CreateBookCommand request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateBookCommand(
            request.Title,
            request.Description,
            request.SerialNumber);
        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(
        [FromRoute] Guid id,
        [FromBody][Required] UpdateBookRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateBookCommand(
            id,
            request.Title,
            request.Description,
            request.SerialNumber);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteBookCommand(id);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPost("{id}/add-author)")]
    public async Task<ActionResult> AssignAuthor(
        [FromRoute] Guid id,
        [FromBody][Required] Guid authorId,
        CancellationToken cancellationToken = default)
    {
        var command = new AssignAuthorCommand(id, authorId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}/remove-author")]
    public async Task<ActionResult> RemoveAuthor(
        [FromRoute] Guid id,
        [FromBody][Required] Guid authorId,
        CancellationToken cancellationToken = default)
    {
        var command = new RemoveAuthorCommand(id, authorId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet("get-by-name/{name}")]
    public async Task<ActionResult> GetBookByName(
        [FromRoute] string name,
        CancellationToken cancellationToken = default)
    {
        var query = new GetBookByNameQuery(name);
        var bookByName = await mediator.Send(query, cancellationToken);
        return Ok(bookByName);
    }
}
