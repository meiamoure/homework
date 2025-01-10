namespace Hmw7;
public static class Logger
{
    private static readonly object s_fileLock = new();
    private static readonly StreamWriter s_writer = new StreamWriter("logs.txt", append: true)
    {
        AutoFlush = true
    };

    public static void Log(string message)
    {
        lock (s_fileLock)
        {
            s_writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {message}");
        }
    }
}
