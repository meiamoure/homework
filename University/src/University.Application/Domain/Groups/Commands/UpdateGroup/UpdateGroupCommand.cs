using MediatR;

namespace University.Application.Domain.Groups.Commands.UpdateGroup;

public record UpdateGroupCommand(
    Guid Id,
    string Name) : IRequest;