using System.Collections;

namespace Task4;

public class Template<T> : IEnumerable<T>
{
    private T[] _data;
    public event Action? OnExpandedEvent;

    public Template()
    {
        _data = [];
    }

    public void Add(T element)
    {
        var newData = new T[_data.Length + 1];
        Array.Copy(_data, newData, _data.Length);
        newData[_data.Length] = element;
        _data = newData;

        OnExpandedEvent?.Invoke();
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _data.Length)
                throw new IndexOutOfRangeException("Index out of bounds");
            return _data[index];
        }
        set
        {
            if (index < 0 || index >= _data.Length)
                throw new IndexOutOfRangeException("Index out of bounds");
            _data[index] = value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var i in _data)
        {
            yield return i;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

