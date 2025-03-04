using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.EF.Core.LibraryDb;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public const string LibraryDbSchema = "library";

    public const string LibraryMigrationHistory = "__LibraryMigrationHistory";

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DbSet<BookAuthor> AuthorBooks { get; set; }

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
    }
}
