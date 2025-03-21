using University.Core.Domain.Groups.Models;
using University.Core.Domain.Students.Data;

namespace University.Core.Domain.Students.Models;
public class Student
{
    private Student()
    {
    }

    private Student(Guid id, string firstName, string lastName, Guid groupId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        GroupId = groupId;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid GroupId { get; private set; }
    public Group Group { get; private set; } = null!;

    public static Student Create(CreateStudentData data)
    {
        return new Student(
            Guid.NewGuid(),
            data.FirstName,
            data.LastName,
            data.GroupId
            );
    }

    public void Update(UpdateStudentData data)
    {
        FirstName = data.FirstName;
        LastName = data.LastName;
    }

    public void ChangeGroup(ChangeStudentGroupData data)
    {
        GroupId = data.NewGroupId;
    }
}
