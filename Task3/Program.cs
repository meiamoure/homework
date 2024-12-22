using Task3;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose task:");
        Console.WriteLine("1. Task 1");
        Console.WriteLine("2. Task 2");
        Console.WriteLine("3. Task 3");
        Console.WriteLine("4. Task 4");
        Console.WriteLine("5. Task 5");
        Console.WriteLine("6. Task 6");
        Console.WriteLine("7. Task 7");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Solve1.Run();
                break;
            case "2":
                Solve2.Run();
                break;
            case "3":
                Solve3.Run();
                break;
            case "4":
                Solve4.Run();
                break;
            case "5":
                Solve5.Run();
                break;
            case "6":
                Solve6.Run();
                break;
            case "7":
                Solve7.Run();
                break;
            default:
                Console.WriteLine("Task does not exist.");
                break;
        }
    }
}