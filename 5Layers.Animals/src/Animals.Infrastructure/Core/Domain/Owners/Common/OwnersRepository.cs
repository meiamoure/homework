using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Core.Domain.Animals.Models;
using Animals.Core.Domain.Owners.Common;
using Animals.Core.Domain.Owners.Models;
using Microsoft.EntityFrameworkCore;

namespace Animals.Infrastructure.Core.Domain.Animals.Common;

public class OwnersRepository(AnimalsDbContext dbContext) : IOwnersRepository
{
    public async Task<Owner> GetOwnerById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Owners
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Owner was not found");
    }

    public void Add(Owner owner)
    {
        dbContext.Add(owner);
    }

    public void Delete(Owner owner)
    {
        dbContext.Remove(owner);
    }
}
