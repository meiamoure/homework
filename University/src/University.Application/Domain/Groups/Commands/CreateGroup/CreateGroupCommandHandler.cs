using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Data;
using University.Core.Domain.Groups.Models;

namespace University.Application.Domain.Groups.Commands.CreateGroup;

public class CreateGroupCommandHandler(
    IGroupRepository  groupsRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateGroupCommand, Guid>
{
    public async Task<Guid> Handle(CreateGroupCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateGroupData(
            command.Name,
            command.DepartmentId);

        var group = Group.Create(data);

        groupsRepository.Add(group);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return group.Id;
    }
}