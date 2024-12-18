namespace Task2;

public static class Program
{
    public static void Main()
    {
        var library = new Library();

        library.AddBook(new Book { Title = "War and Peace", Author = "Leo Tolstoy", Edition = "1st Edition" });
        library.AddBook(new Book { Title = "Crime and Punishment", Author = "Fedor Dostoevsky", Edition = "2nd Edition" });

        library.TakeBook("War and Peace");

        library.TakeBook("War and Peace");

        library.EditEdition("1st Edition", "First Edition");

        var searchStrategies = new List<IBookSearch>
        {
            new SearchByAuthor(),
            new SearchByName(),
            new SearchByEdition()
        };

        Console.WriteLine("Enter the type of search (Author, Title, Edition):");
        var searchType = Console.ReadLine();

        Console.WriteLine("Enter the query:");
        var query = Console.ReadLine();

        if (string.IsNullOrEmpty(query))
        {
            Console.WriteLine("Query can't be null/empty.");
            return;
        }

        var strategy = searchStrategies.FirstOrDefault(s =>
        s.GetType().Name.Equals($"SearchBy{searchType}", StringComparison.OrdinalIgnoreCase));

        if (strategy != null)
        {
            var books = library.GetAllBooks();

            var results = strategy.Search(books, query);

            if (results.Any())
            {
                Console.WriteLine("Search results:");
                foreach (var book in results)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Edition: {book.Edition}");
                }
            }
        }
    }
}

