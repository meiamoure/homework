using Library.Persistence.EF.Core.LibraryDb;
using Library.Application.Common;
using Library.Application.Domain.Books.Queries.GetBooks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Books.Queries.GetBooks;
public class GetBooksQueryHandler(LibraryDbContext dbContext) :
    IRequestHandler<GetBooksQuery, PageResponse<BookDto[]>>
{
    public async Task<PageResponse<BookDto[]>> Handle(
        GetBooksQuery query, CancellationToken cancellationToken)
    {
        var skip = query.PageSize * (query.Page - 1);

        var sqlQuery = dbContext.Books
            .AsNoTracking()
            .OrderBy(b => b.Title);
        var count = await sqlQuery.CountAsync(cancellationToken);

        var books = await sqlQuery
            .OrderBy(b => b.Title)
            .Skip(skip)
            .Take(query.PageSize)
            .Select(x => new BookDto(
                x.Id,
                x.Title,
                x.Description,
                x.SerialNumber
            ))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<BookDto[]>(count, books);
    }
}
