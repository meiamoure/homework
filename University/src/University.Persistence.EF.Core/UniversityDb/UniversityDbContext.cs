using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.Groups.Models;
using University.Core.Domain.Students.Models;

namespace University.Persistence.EF.Core.UniversityDb;

public class UniversityDbContext(DbContextOptions<UniversityDbContext> options) : DbContext(options)
{
    public const string LibraryDbSchema = "university";

    public const string LibraryMigrationHistory = "__UniversityMigrationHistory";

    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<> AuthorBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (env == "Development")
        {
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(LibraryDbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
    }
}