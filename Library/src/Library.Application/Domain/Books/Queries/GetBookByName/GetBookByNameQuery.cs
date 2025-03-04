using Library.Application.Domain.Books.Queries.GetBooks;
using MediatR;

namespace Library.Application.Domain.Books.Queries.GetBookByName;
public record GetBookByNameQuery(string Title) : IRequest<BookDto>;
