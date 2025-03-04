using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Common;
public interface IBookRepository
{
    Task<Book> GetById(Guid id, CancellationToken cancellationToken);

    void Add(Book book);

    void Delete(Book book);
}
