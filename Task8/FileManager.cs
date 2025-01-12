namespace Task8;
public class FileManager : IFileManager
{
    public void Write(string fileName, string content)
    {
        File.WriteAllText(fileName, content);
    }

    public Task WriteAsync(string fileName, string content)
    {
        return File.WriteAllTextAsync(fileName, content);
    }

    public void Delete(string fileName)
    {
        File.Delete(fileName);
    }

    public Task DeleteAsync(string fileName)
    {
        return Task.Run(() => File.Delete(fileName));
    }
}
