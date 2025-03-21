using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.Faculties.Common;
using University.Persistence.EF.Core.UniversityDb;

namespace University.Infrastructure.Core.Domain.Faculties;
public class FacultiesRepository(UniversityDbContext dbContext) : IFacultyRepository
{
    public async Task<Faculty> GetFacultyById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Faculties
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Faculty was not found");
    }

    public void Add(Faculty faculty)
    {
        dbContext.Add(faculty);
    }

    public void Delete(Faculty faculty)
    {
        dbContext.Remove(faculty);
    }
}
