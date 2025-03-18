using MediatR;

namespace University.Application.Domain.Groups.Commands.CreateGroup;

public record CreateGroupCommand(
    string Name,
    Guid DepartmentId) : IRequest<Guid>;