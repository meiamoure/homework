using MediatR;
using University.Core.Common;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Data;

namespace University.Application.Domain.Students.Commands.UpdateStudent;
public class UpdateStudentCommandHandler(
    IStudentRepository studentRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateStudentCommand>
{
    public async Task Handle(
        UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetStudentById(
            command.Id,
            cancellationToken);

        var data = new UpdateStudentData(
            command.FirstName,
            command.LastName);
        student.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
