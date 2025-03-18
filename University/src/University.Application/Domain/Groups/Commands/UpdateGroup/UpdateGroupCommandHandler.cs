using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Data;

namespace University.Application.Domain.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandHandler( 
    IGroupRepository  groupsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateGroupCommand>
{
    public async Task Handle(UpdateGroupCommand command, CancellationToken cancellationToken)
    {
        var group = await groupsRepository.GetGroupById(command.Id, cancellationToken);
        var data = new UpdateGroupData(command.Name);
        group.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}