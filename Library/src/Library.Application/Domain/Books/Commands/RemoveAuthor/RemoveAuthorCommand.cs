using MediatR;

namespace Library.Application.Domain.Books.Commands.RemoveAuthor;
public record RemoveAuthorCommand(Guid BookId, Guid AuthorId) : IRequest;
