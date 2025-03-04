using MediatR;

namespace Library.Application.Domain.Books.Commands.AssignAuthor;
public record AssignAuthorCommand(Guid AuthorId, Guid BookId) : IRequest;
