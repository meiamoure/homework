using Library.Application.Common;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using Library.Persistence.EF.Core.LibraryDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Authors.Queries.GetAuthors;
public class GetAuthorsQueryHandler(LibraryDbContext dbContext)
    : IRequestHandler<GetAuthorsQuery, PageResponse<AuthorDtoQuery[]>>
{
    public async Task<PageResponse<AuthorDtoQuery[]>> Handle(
        GetAuthorsQuery query, CancellationToken cancellationToken)
    {
        var skip = query.PageSize * (query.Page - 1);

        var sqlQuery = dbContext.Authors
           .AsNoTracking()
           .OrderBy(o => o.LastName);
        var count = await sqlQuery.CountAsync(cancellationToken);

        var authors = await sqlQuery
            .OrderBy(a => a.LastName)
            .Skip(skip)
            .Take(query.PageSize)
            .Select(a => new AuthorDtoQuery(
                a.Id,
                a.FirstName,
                a.LastName))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<AuthorDtoQuery[]>(count, authors);
    }
}
