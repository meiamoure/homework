namespace AnimalHotel.Animals;

public class Cat : Animal, IAnimal, IComparable<Cat>
{
    public Cat(string name, Owner owner, int age, string color)
        : base(name, owner, age, color) {}

    public void Meow()
    {
        Console.WriteLine($"{nameof(Cat)} is meowing");
    }
    
    public static Cat CreateCat(string name, Owner owner, int age, string color)
    {
        return new Cat(name, owner, age, color);
    }
    
    // https://refactoring.guru/design-patterns/factory-method
    public int CompareTo(Cat? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }

}