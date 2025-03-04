using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;
public record UpdateAuthorCommand(
    Guid Id,
    string FirstName,
    string LastName) : IRequest;
