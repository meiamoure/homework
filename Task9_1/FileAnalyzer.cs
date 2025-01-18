namespace Task9_1;

public class FileAnalyzer : IFileAnalyzer
{
    public void Analyze(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("File dont have numbers");
            return;
        }

        Console.WriteLine($"Count of numbers: {numbers.Count}");
        Console.WriteLine($"Arithmetic mean: {numbers.Average():F2}");
        Console.WriteLine($"Standard deviation: {StandardDeviation(numbers):F2}");
        Console.WriteLine($"Median: {Median(numbers):F2}");
        Console.WriteLine($"Mode: {Mode(numbers)}");
    }

    private double StandardDeviation(List<int> numbers)
    {
        var average = numbers.Average();
        var sumSqOfdiff = numbers.Select(num => Math.Pow(num - average, 2)).Sum();
        return Math.Sqrt(sumSqOfdiff / numbers.Count - 1);
    }

    private double Median(List<int> numbers)
    {
        var sortNum = numbers.OrderBy(n => n).ToList();
        var count = sortNum.Count();

        if (count % 2 == 0)
        {
            return (sortNum[count / 2 - 1] + sortNum[count / 2]) / 2.0;
        }
        else
        {
            return sortNum[count / 2];
        }
    }

    private int Mode(List<int> numbers)
    {
        return numbers.GroupBy(v => v)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
    }
}
