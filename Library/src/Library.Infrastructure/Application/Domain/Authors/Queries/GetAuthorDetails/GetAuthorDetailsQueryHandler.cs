using Library.Application.Domain.Authors.Queries.GetAuthorDetails;
using Library.Persistence.EF.Core.LibraryDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Authors.Queries.GetAuthorDetails;
public class GetAuthorDetailsQueryHandler(LibraryDbContext dbContext)
    : IRequestHandler<GetAuthorsDetailsQuery, AuthorDetailsDto>
{
    public async Task<AuthorDetailsDto> Handle(
        GetAuthorsDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var author = await dbContext
                   .Authors
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
               ?? throw new ArgumentException($"Author with id: {query.Id} was not found.", nameof(query));

        return new AuthorDetailsDto(
            author.Id,
            author.FirstName,
            author.LastName);
    }
}
