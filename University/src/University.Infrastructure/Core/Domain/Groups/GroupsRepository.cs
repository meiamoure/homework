using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;
using University.Persistence.EF.Core.UniversityDb;

namespace University.Infrastructure.Core.Domain.Groups;
public class GroupsRepository(UniversityDbContext dbContext) : IGroupRepository
{
    public async Task<Group> GetGroupById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Groups
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Group was not found");
    }

    public void Add(Group group)
    {
        dbContext.Add(group);
    }

    public void Delete(Group group)
    {
        dbContext.Remove(group);
    }
}
