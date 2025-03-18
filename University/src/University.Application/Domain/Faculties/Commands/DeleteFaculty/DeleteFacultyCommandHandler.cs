using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Faculties.Common;

namespace University.Application.Domain.Faculties.Commands.DeleteFaculty;

public class DeleteFacultyCommandHandler(
    IFacultyRepository facultiesRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteFacultyCommand>
{
    public async Task Handle(DeleteFacultyCommand command, CancellationToken cancellationToken)
    {
        var faculty = await facultiesRepository.GetFacultyById(command.Id, cancellationToken);
        facultiesRepository.Delete(faculty);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}