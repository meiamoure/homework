namespace University.Core.Domain.Students.Data;
public record CreateStudentData(
    string FirstName,
    string LastName,
    Guid GroupId
);
