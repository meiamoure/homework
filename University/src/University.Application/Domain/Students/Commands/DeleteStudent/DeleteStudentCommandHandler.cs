using MediatR;
using University.Core.Common;
using University.Core.Domain.Students.Common;

namespace University.Application.Domain.Students.Commands.DeleteStudent;
public class DeleteStudentCommandHandler(
    IStudentRepository studentRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteStudentCommand>
{
    public async Task Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetStudentById(command.Id, cancellationToken);
        studentRepository.Delete(student);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
