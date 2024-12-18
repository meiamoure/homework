namespace Task2;

public interface IBookSearch
{
    IEnumerable<Book> Search(IEnumerable<Book> books, string query);
}