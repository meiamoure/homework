namespace Task9;
public static class Program
{
    private static void Main()
    {
        var filePath = @"D:\Studies\Course\homework\numbers.txt";
        var fileWriter = new FileWriter();
        var randomNum = new RandomNum();
        var run = new AppRunner(fileWriter, randomNum, filePath);
        run.Run();
    }
}
