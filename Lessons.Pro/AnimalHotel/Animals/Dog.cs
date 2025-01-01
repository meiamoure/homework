namespace AnimalHotel.Animals;

public class Dog : Animal, IAnimal, IComparable<Dog>
{
    public Dog(string name, Owner owner, int age, string color)
        : base(name, owner, age, color) {}
        
    public void Bark()
    {
        Console.WriteLine($"{nameof(Dog)} is barking");
    }

    // https://refactoring.guru/design-patterns/factory-method
    public static Dog CreateDog(string name, Owner owner, int age, string color)
    {
        return new Dog(name, owner, age, color);
    }

    public int CompareTo(Dog? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}