namespace Task9;

public class FileWriter : IFileWriter
{
    public void Writer(string filePath, string content)
    {
        File.AppendAllText(filePath, content + Environment.NewLine);
    }
}
