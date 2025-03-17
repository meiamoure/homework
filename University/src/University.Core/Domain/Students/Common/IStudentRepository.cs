using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Common;
public interface IStudentRepository
{
    Task<Student> GetStudentById(Guid studentId, CancellationToken cancellationToken);
    void Add(Student student);
    void Delete(Student student);
}
