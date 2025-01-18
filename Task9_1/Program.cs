namespace Task9_1;
public class Program
{
    private static void Main()
    {
        var filePath = @"D:\Studies\Course\homework\numbers.txt";
        var fileReader = new FileReader();
        var analyzer = new FileAnalyzer();
        var application = new AnalyzerRunner(fileReader, analyzer, filePath);

        application.Run();
    }
}
