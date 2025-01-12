namespace Task8;
public interface IFileManager
{
    Task WriteAsync(string fileName, string data);
    Task DeleteAsync(string fileName);
    void Delete(string fileName);
    void Write(string fileName, string content);
}
