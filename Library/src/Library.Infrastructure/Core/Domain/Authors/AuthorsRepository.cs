using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using Library.Persistence.EF.Core.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Authors;

public class AuthorsRepository(LibraryDbContext dbContext) : IAuthorsRepository
{
    public async Task<Author> GetAuthorById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Authors
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Author was not found");
    }

    public void Add(Author author)
    {
        dbContext.Add(author);
    }

    public void Delete(Author author)
    {
        dbContext.Remove(author);
    }
}
