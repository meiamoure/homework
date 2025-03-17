using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Departments.Common;
public interface IDepartmentRepository
{
    Task<Department> GetDepartmentById(Guid departmentId, CancellationToken cancellationToken);
    void Add(Department department);
    void Delete(Department facdepartmentulty);
}
