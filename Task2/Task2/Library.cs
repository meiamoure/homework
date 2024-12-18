namespace Task2;

public class Library
{
    private readonly Book[] _books = new Book[100];
    private int _bookCount = 0;

    public void AddBook(Book book)
    {
        if (_bookCount < _books.Length)
        {
            _books[_bookCount] = book;
            _bookCount++;
            Console.WriteLine($"Book '{book.Title}' has been added to Library.");
        }
        else
        {
            Console.WriteLine("The library is full. Cannot add more books.");
        }
    }

    public void TakeBook(string title)
    {
        for (var i = 0; i < _bookCount; i++)
        {
            if (_books[i].Title == title && _books[i].IsAvaliable)
            {
                _books[i].IsAvaliable = false;
                Console.WriteLine($"Book '{_books[i].Title}' has been taken.");
                return;
            }
        }
        Console.WriteLine($"Book '{title}' is not available or does not exist in the library.");
    }

    public void EditEdition(string oldEdition, string newEdition)
    {
        var renamed = false;
        for (var i = 0; i < _bookCount; i++)
        {
            if (_books[i].Edition.Equals(oldEdition, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Book '{_books[i].Title}', edition '{oldEdition}' has been renamed to '{newEdition}'.");
                _books[i].Edition = newEdition;
                renamed = true;
            }
        }

        if (!renamed)
        {
            Console.WriteLine($"No books found '{oldEdition}'.");
        }
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _books.Take(_bookCount);
    }
}
