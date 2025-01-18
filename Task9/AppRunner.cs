namespace Task9;
public class AppRunner(IFileWriter fileWriter, RandomNum numberGenerator, string filePath)
{
    private readonly IFileWriter _fileWriter = fileWriter;
    private readonly RandomNum _numberGenerator = numberGenerator;
    private readonly string _filePath = filePath;

    public void Run()
    {
        Console.WriteLine("Generation...");

        var numbers = _numberGenerator.Randomer();
        foreach (var number in numbers)
        {
            _fileWriter.Writer(_filePath, number.ToString());
            Console.WriteLine($"Number added: {number}");
        }
    }
}
