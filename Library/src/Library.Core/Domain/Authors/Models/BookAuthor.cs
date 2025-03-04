using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Authors.Models;
public class BookAuthor
{
    private BookAuthor()
    {
    }

    private BookAuthor(Guid bookId, Guid authorId)
    {
        BookId = bookId;
        AuthorId = authorId;
    }
    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public Guid AuthorId { get; set; }
    public Author Author { get; set; }

    public static BookAuthor Create(Guid bookId, Guid authorId)
    {
        return new BookAuthor(bookId, authorId);
    }
}
