using MediatR;

namespace University.Application.Domain.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommand(
    string Name,
    Guid FacultyId) : IRequest<Guid>;