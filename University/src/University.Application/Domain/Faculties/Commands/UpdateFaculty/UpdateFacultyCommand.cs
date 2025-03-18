using MediatR;

namespace University.Application.Domain.Faculties.Commands.UpdateFaculty;

public record UpdateFacultyCommand(
    Guid Id,
    string Name) : IRequest;