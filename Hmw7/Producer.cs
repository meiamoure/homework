namespace Hmw7;
public class Producer(IBuffer<int> buffer)
{
    private readonly IBuffer<int> _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
    private readonly Random _random = new Random();

    public void Produce()
    {
        try
        {
            for (var i = 0; i < 20; i++)
            {
                var data = _random.Next(1, 100);
                _buffer.Add(data);
                Logger.Log($"[Producer] Produced: {data}");
                Thread.Sleep(300);
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"[Producer] Error: {ex.Message}");
            Console.WriteLine($"Producer has an error {ex.Message}");
        }
    }
}
