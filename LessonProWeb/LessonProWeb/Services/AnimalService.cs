using LessonProWeb.Models;
using LessonProWeb.Repository;

namespace LessonProWeb.Services;

public class AnimalService
{
    private readonly AnimalRepository _repository = new();

    public List<Animal> GetAllAnimals() => _repository.GetAll();
    public Animal? GetAnimalById(Guid id) => _repository.GetById(id);
    public void AddAnimal(Animal animal) => _repository.Add(animal);
    public void UpdateAnimal(Animal animal) => _repository.Update(animal);
    public void DeleteAnimal(Guid id) => _repository.Delete(id);
}
