using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Data;

namespace University.Application.Domain.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandHandler(
    IFacultyRepository  facultiesRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateFacultyCommand>
{
    public async Task Handle(UpdateFacultyCommand command, CancellationToken cancellationToken)
    {
        var faculty = await facultiesRepository.GetFacultyById(command.Id, cancellationToken);
        var data = new UpdateFacultyData(command.Name);
        faculty.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}