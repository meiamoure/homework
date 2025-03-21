using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Common;
public interface IStudentRepository
{
    public Task<Student> GetStudentById(Guid studentId, CancellationToken cancellationToken);
    public void Add(Student student);
    public void Delete(Student student);
}
