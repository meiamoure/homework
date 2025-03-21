using University.Core.Domain.Departments.Data;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Departments.Models;

public class Department
{
    private Department()
    {
    }

    private Department(Guid id, string name, Guid facultyId)
    {
        Id = id;
        Name = name;
        FacultyId = facultyId;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid FacultyId { get; private set; }
    public Faculty Faculty { get; private set; } = null!;
    public ICollection<Group> Groups { get; private set; } = [];

    public static Department Create(CreateDepartmentData data)
    {
        return new Department(
            Guid.NewGuid(),
            data.Name,
            data.FacultyId);
    }

    public void Update(UpdateDepartmentData data)
    {
        Name = data.Name;
    }
}
