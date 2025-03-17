using MediatR;
using University.Core.Common;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Data;
using University.Core.Domain.Students.Models;

namespace University.Application.Domain.Students.Commands.CreateStudent;
public class CreateStudentCommandHandler(
    IStudentRepository studentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateStudentCommand, Guid>
{
    public async Task<Guid> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateStudentData(command.FirstName, command.LastName, command.GroupId);
        var student = Student.Create(data);

        studentRepository.Add(student);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return student.Id;
    }
}
