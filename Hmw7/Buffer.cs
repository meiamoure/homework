namespace Hmw7;
public class Buffer<T>(int capacity = 10) : IBuffer<T>
{
    private readonly Queue<T> _queue = new Queue<T>();
    private readonly int _capacity = capacity;
    private readonly object _lock = new object();

    public void Add(T item)
    {
        lock (_lock)
        {
            while (_queue.Count >= _capacity)
            {
                Monitor.Wait(_lock);
            }

            _queue.Enqueue(item);
            Monitor.PulseAll(_lock);
        }
    }

    public T Remove()
    {
        lock (_lock)
        {
            while (_queue.Count == 0)
            {
                Monitor.Wait(_lock);
            }

            var item = _queue.Dequeue();
            Monitor.PulseAll(_lock);
            return item;
        }
    }
}
