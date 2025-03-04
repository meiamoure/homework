using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EF.Core.LibraryDb.EntityTypesConfigurations;
internal class BookTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.SerialNumber)
            .HasMaxLength(13)
            .IsRequired();

        builder.HasIndex(x => x.SerialNumber)
            .IsUnique();

        builder
            .Metadata
            .FindNavigation(nameof(Book.Authors))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Authors)
            .WithOne(x => x.Book)
            .HasForeignKey(x => x.BookId);
    }
}
