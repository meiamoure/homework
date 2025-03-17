using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Data;

namespace University.Core.Domain.Faculties.Models;
public class Faculty
{
    private readonly List<Department> _departments = [];

    private Faculty()
    {
    }

    private Faculty(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();

    public static Faculty Create(CreateFacultyData data)
    {
        return new Faculty(
            Guid.NewGuid(),
            data.Name);
    }

    public void Update(UpdateFacultyData data)
    {
        Name = data.Name;
    }
}
