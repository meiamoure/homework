using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Models;
using Library.Persistence.EF.Core.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Books.Common;
public class BooksRepository(LibraryDbContext dbContext) : IBookRepository
{
    public async Task<Book> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Books
            .Include(x => x.Authors)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Book was not found");
    }

    public void Add(Book book)
    {
        dbContext.Add(book);
    }

    public void Delete(Book book)
    {
        dbContext.Remove(book);
    }
}
