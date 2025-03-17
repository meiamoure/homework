using System.Text.RegularExpressions;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Departments.Models;

public class Department
{
    private readonly List<Group> _groups = [];

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
    public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();

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
