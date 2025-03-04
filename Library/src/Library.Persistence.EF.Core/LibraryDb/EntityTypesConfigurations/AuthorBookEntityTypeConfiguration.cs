using Library.Core.Domain.Authors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EF.Core.LibraryDb.EntityTypesConfigurations;
public class AuthorBookEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(x => new { x.BookId, x.AuthorId });
    }
}
