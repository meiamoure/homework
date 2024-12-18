namespace Task2;

public class SearchByAuthor : IBookSearch
{
    public IEnumerable<Book> Search(IEnumerable<Book> books, string query)
    {
        return books.Where(book => book.Author.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}
