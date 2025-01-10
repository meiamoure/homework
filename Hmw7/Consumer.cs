namespace Hmw7;
public class Consumer(IBuffer<int> buffer)
{
    private readonly IBuffer<int> _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
    public void Consume()
    {
        try
        {
            for (var i = 0; i < 20; i++)
            {
                var data = _buffer.Remove();
                Logger.Log($"[Consumer] Consumed: {data}");
                Thread.Sleep(300);
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"[Consumer] Error: {ex.Message}");
            Console.WriteLine($"Consumer encountered an error: {ex.Message}");
        }
    }
}
