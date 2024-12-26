namespace Task4;

public static class Program
{
    public static void Main()
    {
        var template = new Template<int>();

        template.OnExpandedEvent += () => Console.WriteLine("Expanded");

        template.Add(4);
        template.Add(11);
        template.Add(2);
        template.Add(7);

        var numbers = template.OrderBy(x => x);
        var filter = template.Where(x => x > 5);

        Console.WriteLine("Data Array");
        foreach (var item in template)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nArray OrderBy");
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nFiltered Array");
        foreach (var item in filter)
        {
            Console.WriteLine(item);
        }
    }
}


