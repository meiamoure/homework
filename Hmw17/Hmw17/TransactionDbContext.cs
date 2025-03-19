using Microsoft.EntityFrameworkCore;

namespace Hmw17;

public class TransactionDbContext(DbContextOptions<TransactionDbContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("transactions");
        modelBuilder.Entity<Transaction>().ToTable("Transactions");
    }
}
