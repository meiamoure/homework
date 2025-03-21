using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Groups.Common;
public interface IGroupRepository
{
    public Task<Group> GetGroupById(Guid groupId, CancellationToken cancellationToken);
    public void Add(Group group);
    public void Delete(Group group);
}
