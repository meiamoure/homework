using Library.Core.Common;
using Library.Persistence.EF.Core.LibraryDb;

namespace Library.Infrastructure.Core.Common;
public class UnitOfWork(LibraryDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
