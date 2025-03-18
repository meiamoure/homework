using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;

namespace University.Application.Domain.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentCommandHandler(
    IDepartmentRepository  departmentsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDepartmentCommand>
{
    public async Task Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await departmentsRepository.GetDepartmentById(command.Id, cancellationToken);
        departmentsRepository.Delete(department);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}