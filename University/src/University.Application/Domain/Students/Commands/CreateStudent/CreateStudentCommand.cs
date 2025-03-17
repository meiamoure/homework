using MediatR;

namespace University.Application.Domain.Students.Commands.CreateStudent;
public record CreateStudentCommand(
    string FirstName,
    string LastName,
    Guid GroupId) : IRequest<Guid>;
