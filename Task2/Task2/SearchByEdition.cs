namespace Task2;

public class SearchByEdition : IBookSearch
{
    public IEnumerable<Book> Search(IEnumerable<Book> books, string query)
    {
        return books.Where(book => book.Edition.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}
