using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Authors.Common;
public interface IAuthorsRepository
{
    Task<Author> GetAuthorById(Guid authorId, CancellationToken cancellationToken);
    void Add(Author author);
    void Delete(Author author);
}
