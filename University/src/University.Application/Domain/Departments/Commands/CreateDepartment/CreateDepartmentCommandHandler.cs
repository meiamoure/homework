using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Departments.Models;

namespace University.Application.Domain.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler(
    IDepartmentRepository departmentsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateDepartmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateDepartmentData(
            command.Name,
            command.FacultyId);

        var department = Department.Create(data);

        departmentsRepository.Add(department);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return department.Id;
    }
}
