using MediatR;

namespace Library.Application.Domain.Books.Queries.GetBookDetails;
public record GetBookDetailsQuery(Guid Id) : IRequest<BookDetailsDto>;
