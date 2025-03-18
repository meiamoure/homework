using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Data;
using University.Core.Domain.Faculties.Models;

namespace University.Application.Domain.Faculties.Commands.CreateFaculty;

public class CreateFacultyCommandHandler(
    IFacultyRepository  facultiesRepository,
    IUnitOfWork  unitOfWork) : IRequestHandler<CreateFacultyCommand, Guid>
{
    public async Task<Guid> Handle(CreateFacultyCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateFacultyData(command.Name);
        var faculty = Faculty.Create(data);

        facultiesRepository.Add(faculty);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return faculty.Id;
    }
}