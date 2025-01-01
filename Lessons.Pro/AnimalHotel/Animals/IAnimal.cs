namespace AnimalHotel.Animals;

public interface IAnimal
{
    string Name { get; }
    Owner Owner { get; }
    int Age { get; }
    string Color { get; }
    
    void Eat();

    void Sleep();
}