namespace University.Core.Domain.Departments.Data;
public record CreateDepartmentData(
    string Name,
    Guid FacultyId);
