using Library.Core.Domain.Authors.Data;

namespace Library.Core.Domain.Authors.Models;

public class Author
{
    private readonly List<BookAuthor> _books = [];
    private Author()
    {
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public IReadOnlyCollection<BookAuthor> Books => _books.AsReadOnly();

    internal Author(
        Guid id,
        string firstName,
        string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public void Update(UpdateAuthorData data)
    {
        FirstName = data.FirstName;
        LastName = data.LastName;
    }

    public static Author Create(CreateAuthorData data)
    {
        return new Author(
            Guid.NewGuid(),
            data.FirstName,
            data.LastName);
    }
}
