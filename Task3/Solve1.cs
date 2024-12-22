namespace Task3;

public static class Solve1
{
    public static void Run()
    {
        var stringList = new List<string> { "Andrii", "Tree", "Branch", "Abstraction", "Github", "Array" };

        var filteredStrings = stringList
        .Where(s => s.StartsWith("A", StringComparison.OrdinalIgnoreCase));

        foreach (var letter in filteredStrings)
        {
            Console.WriteLine(letter);
        }
    }
}