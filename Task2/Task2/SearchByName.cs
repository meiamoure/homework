namespace Task2;

public class SearchByName : IBookSearch
{
    public IEnumerable<Book> Search(IEnumerable<Book> books, string query)
    {
        return books.Where(book => book.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}
