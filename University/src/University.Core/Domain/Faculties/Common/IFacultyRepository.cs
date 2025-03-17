using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Faculties.Common;
public interface IFacultyRepository
{
    Task<Faculty> GetFacultyById(Guid facultyId, CancellationToken cancellationToken);
    void Add(Faculty faculty);
    void Delete(Faculty faculty);
}
