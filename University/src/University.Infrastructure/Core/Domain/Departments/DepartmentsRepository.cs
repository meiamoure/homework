using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;

namespace University.Infrastructure.Core.Domain.Departments;
public class DepartmentsRepository(UniversityDbContext dbContext) : IDepartmentRepository
{
    public async Task<Department> GetDepartmentById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Departments
            .Include(x => x.Departments)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Department was not found");
    }

    public void Add(Department department)
    {
        dbContext.Add(department);
    }

    public void Delete(Department department)
    {
        dbContext.Remove(department);
    }
}
