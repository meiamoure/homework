namespace AnimalHotel.Animals;

public abstract class Animal : IAnimal, IComparable<Animal>
{
    protected Animal(string name, Owner owner, int age, string color)
    {
        Name = name;
        Age = age;
        Owner = owner;
        Color = color;
    }

    public string Name { get; set; }
    public int Age { get; private set; }
    public string Color { get; private set; }
    
    public Owner Owner { get; private set; }

    public void Eat()
    {
        Console.WriteLine($"{nameof(Animal)} is eating");
    }

    public void Sleep()
    {
        Console.WriteLine($"{nameof(Animal)} is sleeping");
    }

    public int CompareTo(Animal? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return Age.CompareTo(other.Age);
    }

    public static IEnumerable<Animal> SortByAge(IEnumerable<Animal> animals)
    {
        return animals.OrderBy(animal => animal.Age);
    }

    public static IEnumerable<Animal> FilterByOwnerName(IEnumerable<Animal> animals, string ownerName)
    {
        return animals.Where(animal => animal.Owner.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));
    }
}
