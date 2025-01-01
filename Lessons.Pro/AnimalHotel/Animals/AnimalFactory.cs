namespace AnimalHotel.Animals;

// https://refactoring.guru/design-patterns/abstract-factory
public class AnimalFactory : IAnimalFactory
{
    private readonly Dictionary<string, Func<string, Owner, int, string, IAnimal>> _creator;
    public AnimalFactory()
    {
        _creator = new Dictionary<string, Func<string, Owner, int, string, IAnimal>>
        {
            { "Dog", (name, owner, age, color) => new Dog(name, owner, age, color) },
            { "Cat", (name, owner, age, color) => new Cat(name, owner, age, color) }
        };
    }
    public void Registrator(string type, Func<string, Owner, int, string, IAnimal> creator)
    {
        _creator[type] = creator;
    }

    public IAnimal CreateAnimal(string type, string name, Owner owner, int age, string color)
    {
        if(_creator.ContainsKey(type))
        {
            return _creator[type](name, owner, age, color);
        }
        throw new ArgumentException($"Animal type {type} is not supported");
    }
}

