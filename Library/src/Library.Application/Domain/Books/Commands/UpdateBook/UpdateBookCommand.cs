using MediatR;

namespace Library.Application.Domain.Books.Commands.UpdateBook;
public record UpdateBookCommand(
    Guid Id,
    string Title,
    string Description,
    string SerialNumber) : IRequest;
