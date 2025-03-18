using MediatR;

namespace University.Application.Domain.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand(
    Guid Id,
    string Name) : IRequest;