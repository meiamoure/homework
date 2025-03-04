using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Models;
public class Book
{
    private readonly List<BookAuthor> _authors = [];

    private Book()
    {
    }

    private Book(
        Guid id,
        string title,
        string description,
        string serialNumber)
    {
        Id = id;
        Title = title;
        Description = description;
        SerialNumber = serialNumber;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string SerialNumber { get; private set; }
    public IReadOnlyCollection<BookAuthor> Authors => _authors.AsReadOnly();

    public static Book Create(CreateBookData data)
    {
        return new Book(
            Guid.NewGuid(),
            data.Title,
            data.Description,
            data.SerialNumber
        );
    }

    public void Update(UpdateBookData data)
    {
        Title = data.Title;
        Description = data.Description;
        SerialNumber = data.SerialNumber;
    }

    public void AssignAuthor(Author author)
    {
        if (_authors.All(x => x.AuthorId != author.Id))
        {
            var ba = BookAuthor.Create(Id, author.Id);
            _authors.Add(ba);
        }
    }

    public void AssignAuthors(Author[] author)
    {
        var bookAuthors = author
            .Where(a => _authors.All(x => x.AuthorId != a.Id))
            .Select(author => BookAuthor.Create(Id, author.Id));

        _authors.AddRange(bookAuthors);
    }

    public void RemoveAuthor(Author author)
    {
        var ra = _authors.FirstOrDefault(x => x.AuthorId == author.Id);
        if (ra is not null)
        {
            _authors.Remove(ra);
        }
    }
}
