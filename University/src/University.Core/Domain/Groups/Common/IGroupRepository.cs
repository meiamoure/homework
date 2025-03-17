using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Groups.Common;
public interface IGroupRepository
{
    Task<Group> GetGroupById(Guid groupId, CancellationToken cancellationToken);
    void Add(Group group);
    void Delete(Group group);
}
