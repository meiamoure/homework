using System.Diagnostics;

namespace Task8;
public static class Timer
{
    public static long Time(Action action)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    public static async Task<long> Time(Func<Task> asyncAction)
    {
        var stopwatch = Stopwatch.StartNew();
        await asyncAction();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
