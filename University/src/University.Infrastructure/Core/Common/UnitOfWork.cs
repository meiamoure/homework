using University.Core.Common;

namespace University.Infrastructure.Core.Common;
public class UnitOfWork(UniversityDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
