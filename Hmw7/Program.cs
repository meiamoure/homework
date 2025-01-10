namespace Hmw7;
public static class Program
{
    public static void Main()
    {
        try
        {
            IBuffer<int> buffer = new Buffer<int>(10);
            var producer = new Producer(buffer);
            var consumer = new Consumer(buffer);

            var producerThread = new Thread(producer.Produce);
            var consumerThread = new Thread(consumer.Consume);

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();

            Console.WriteLine("Work completed. Logs written to the file");
        }
        catch (Exception ex)
        {
            Logger.Log($"[Main] Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
