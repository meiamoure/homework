namespace Task3;

public static class Solve6
{
    public static void Run()
    {
        var books = new List<Book>
        {
            new() { Title = "Dune", Author = "Frank Herbert", DateOfPublication = new DateTime(1965, 8, 1), Genre = "Fantasy" },
            new() { Title = "The Martian", Author = "Andy Weir", DateOfPublication = new DateTime(2011, 10, 28), Genre = "Fantasy" },
            new() { Title = "The Hunger Games", Author = "Suzanne Collins", DateOfPublication = new DateTime(2008, 9, 14), Genre = "Drama" },
            new() { Title = "To Kill a Mockingbird", Author = "Harper Lee", DateOfPublication = new DateTime(1960, 7, 11), Genre = "Classic" },
            new() { Title = "Children of Time", Author = "Adrian Tchaikovsky", DateOfPublication = new DateTime(2015, 6, 4), Genre = "Fantasy" }
        };

        var filteredStrings = books.FindAll(book =>
        book.DateOfPublication > new DateTime(2010, 1, 1) &&
        book.Genre.Equals("Fantasy", StringComparison.OrdinalIgnoreCase));

        foreach (var book in filteredStrings)
        {
            Console.WriteLine($"Title: {book.Title}, {book.DateOfPublication:yyyy-MM-dd}, {book.Genre}");
        }
    }

}