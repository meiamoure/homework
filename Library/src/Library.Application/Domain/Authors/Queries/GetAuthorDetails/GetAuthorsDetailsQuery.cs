using MediatR;

namespace Library.Application.Domain.Authors.Queries.GetAuthorDetails;
public record GetAuthorsDetailsQuery(Guid Id) : IRequest<AuthorDetailsDto>;
