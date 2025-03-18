using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;

namespace University.Application.Domain.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler(
    IGroupRepository  groupsRepository, 
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
    {
        var author = await groupsRepository.GetGroupById(command.GroupId, cancellationToken);
        groupsRepository.Delete(author);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}