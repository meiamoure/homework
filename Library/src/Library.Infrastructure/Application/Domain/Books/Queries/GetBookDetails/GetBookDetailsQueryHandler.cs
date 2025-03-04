using Library.Application.Domain.Books.Queries.GetBookDetails;
using Library.Persistence.EF.Core.LibraryDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Books.Queries.GetBookDetails;
public class GetBookDetailsQueryHandler(LibraryDbContext dbContext)
    : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
{
    public async Task<BookDetailsDto> Handle(
        GetBookDetailsQuery query, CancellationToken cancellationToken)
    {
        var book = await dbContext
            .Books
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
            ?? throw new ArgumentException($"Book with id: {query.Id} was not found.", nameof(query));

        return new BookDetailsDto(
            book.Id,
            book.Title,
            book.Description,
            book.SerialNumber);
    }
}
