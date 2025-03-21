using University.Core.Domain.Departments.Models;
using University.Core.Domain.Groups.Data;
using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Groups.Models;
public class Group
{
    private Group()
    {
    }

    private Group(Guid id, string name, Guid departmentId)
    {
        Id = id;
        Name = name;
        DepartmentId = departmentId;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Department Department { get; private set; } = null!;

    public ICollection<Student> Students { get; private set; } = [];

    public static Group Create(CreateGroupData data)
    {
        return new Group(
            Guid.NewGuid(),
            data.Name,
            data.DepartmentId);
    }

    public void Update(UpdateGroupData data)
    {
        Name = data.Name;
    }
}
