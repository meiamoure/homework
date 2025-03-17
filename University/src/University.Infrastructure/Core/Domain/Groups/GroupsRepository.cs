using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;

namespace University.Infrastructure.Core.Domain.Groups;
public class GroupsRepository(UniversityDbContext dbContext) : IGroupRepository
{
    public async Task<Group> GetGroupById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Groups
            .Include(x => x.Groups)
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
