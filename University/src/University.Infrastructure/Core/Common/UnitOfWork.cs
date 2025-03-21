using University.Core.Common;
using University.Persistence.EF.Core.UniversityDb;

namespace University.Infrastructure.Core.Common;
public class UnitOfWork(UniversityDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
