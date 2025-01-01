using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class RomashkaHotel : IEnumerable<IAnimal>
{
    private IAnimal[] _animals = new IAnimal[4];
    private int _count = 0;
    private int _capacity = 4;
    
    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Eat();
            }
        }
    }
    
    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Sleep();
            }
        }
    }
    
    public void AddAnimal(object animal)
    {
        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Resize(ref _animals, _capacity);
        }
        
        _animals[_count++] = (IAnimal)animal;
    }
    
    public void PrintAnimals()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                Console.WriteLine(iAnimal.Name);
            }
        }
    }
    
    public object this[int index]
    {
        get => _animals[index];
        set => _animals[index] = (IAnimal)value;
    }

     public IEnumerator<IAnimal> GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}