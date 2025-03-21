using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Departments.Common;
public interface IDepartmentRepository
{
    public Task<Department> GetDepartmentById(Guid departmentId, CancellationToken cancellationToken);
    public void Add(Department department);
    public void Delete(Department department);
}
