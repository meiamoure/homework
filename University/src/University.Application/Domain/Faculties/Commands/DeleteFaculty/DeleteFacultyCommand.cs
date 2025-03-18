using MediatR;

namespace University.Application.Domain.Faculties.Commands.DeleteFaculty;

public record DeleteFacultyCommand(Guid Id) : IRequest;