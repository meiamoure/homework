using LessonProWeb.Data;
using LessonProWeb.Models;

namespace LessonProWeb.Repository;

public class AnimalRepository
{
    public List<Animal> GetAll() => AnimalData.Animals;
    public Animal? GetById(Guid id) => AnimalData.Animals.FirstOrDefault(a => a.Id == id);
    public void Add(Animal animal) => AnimalData.Animals.Add(animal);
    public void Update(Animal animal)
    {
        var existing = GetById(animal.Id);
        if (existing != null)
        {
            existing.Name = animal.Name;
            existing.Age = animal.Age;
        }
    }
    public void Delete(Guid id) => AnimalData.Animals.RemoveAll(a => a.Id == id);
}
