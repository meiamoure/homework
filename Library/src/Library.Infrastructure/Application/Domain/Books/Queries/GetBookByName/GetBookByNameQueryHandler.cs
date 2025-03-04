using Library.Application.Domain.Books.Queries.GetBookByName;
using Library.Application.Domain.Books.Queries.GetBooks;
using Library.Persistence.EF.Core.LibraryDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Books.Queries.GetBookByName;
public class GetBookByNameQueryHandler(LibraryDbContext dbContext) :
    IRequestHandler<GetBookByNameQuery, BookDto>
{
    public async Task<BookDto> Handle(GetBookByNameQuery query, CancellationToken cancellationToken)
    {
        var book = await dbContext
        .Books
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Title == query.Title, cancellationToken)
        ?? throw new ArgumentException($"Book with title: {query.Title} was not found.", nameof(query));

        return new BookDto(
           book.Id,
           book.Title,
           book.Description,
           book.SerialNumber);
    }
}
