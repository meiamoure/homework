using Library.Core.Domain.Books.Checkers;
using Library.Persistence.EF.Core.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Books.Checkers;
public class SerialNumberMustBeUniqueChecker(LibraryDbContext dbContext) : ISerialNumberMustBeUniqueChecker
{
    public async Task<bool> IsUnique(string serialNumber, CancellationToken cancellationToken = default)
    {
        return await dbContext.Books.AllAsync(x => x.SerialNumber != serialNumber, cancellationToken);
    }
}
