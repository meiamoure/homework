using MediatR;

namespace Library.Application.Domain.Authors.Commands.DeleteAuthor;
public record DeleteAuthorCommand(Guid Id) : IRequest;

