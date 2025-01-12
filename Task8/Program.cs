namespace Task8;
public static class Program
{
    public static async Task Main()
    {
        var fileHandler = new FileManager();
        var runner = new Runner(fileHandler);

        Console.WriteLine("Synchronous...");
        var syncTime = Timer.Time(runner.SyncMethod);
        Console.WriteLine($"Synchronous execution took: {syncTime} ms");

        Console.WriteLine("\nAsynchronous...");
        var asyncTime = await Timer.Time(runner.AsyncMethod);
        Console.WriteLine($"Asynchronous execution took: {asyncTime} ms");
    }
}
