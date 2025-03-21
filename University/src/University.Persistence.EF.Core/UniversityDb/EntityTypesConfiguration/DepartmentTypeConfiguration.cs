using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Models;

namespace University.Persistence.EF.Core.UniversityDb.EntityTypesConfiguration;

public class DepartmentTypeConfiguration
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(x => x.Faculty)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.FacultyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Groups)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId);
    }
}
