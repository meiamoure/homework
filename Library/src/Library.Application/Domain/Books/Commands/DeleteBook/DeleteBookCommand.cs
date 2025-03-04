using MediatR;

namespace Library.Application.Domain.Books.Commands.DeleteBook;
public record DeleteBookCommand(Guid Id) : IRequest;
