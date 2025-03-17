﻿using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Models;

namespace University.Infrastructure.Core.Domain.Students;
public class StudentsRepository(UniversityDbContext dbContext) : IStudentRepository
{
    public async Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Students
            .Include(x => x.Students)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Student was not found");
    }

    public void Add(Student student)
    {
        dbContext.Add(student);
    }

    public void Delete(Student student)
    {
        dbContext.Remove(student);
    }
}
