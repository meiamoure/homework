namespace AnimalHotel.Animals;
public interface IAnimalFactory
{
    IAnimal CreateAnimal(string type, string name, Owner owner, int age, string color);
    void Registrator(string type, Func<string, Owner, int, string, IAnimal> creator);
}