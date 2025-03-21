using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Faculties.Common;
public interface IFacultyRepository
{
    public Task<Faculty> GetFacultyById(Guid facultyId, CancellationToken cancellationToken);
    public void Add(Faculty faculty);
    public void Delete(Faculty faculty);
}
