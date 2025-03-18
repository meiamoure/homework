using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Data;

namespace University.Application.Domain.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandHandler(
    IDepartmentRepository  departmentsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateDepartmentCommand>
{
    public async Task Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await departmentsRepository.GetDepartmentById(command.Id, cancellationToken);
        var data = new UpdateDepartmentData(command.Name);
        department.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}