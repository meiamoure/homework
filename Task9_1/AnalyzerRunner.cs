namespace Task9_1;

internal class AnalyzerRunner(IFileReader fileReader, IFileAnalyzer analyzer, string filePath)
{
    private readonly IFileReader _fileReader = fileReader;
    private readonly IFileAnalyzer _analyzer = analyzer;
    private readonly string _filePath = filePath;

    public void Run()
    {
        Console.WriteLine("Analyzed: ");

        var numbers = _fileReader.ReadNumbers(_filePath);
        _analyzer.Analyze(numbers);
    }
}
