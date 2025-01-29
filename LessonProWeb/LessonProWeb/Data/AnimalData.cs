using LessonProWeb.Models;

namespace LessonProWeb.Data;

public static class AnimalData
{
    public static List<Animal> Animals = new()
    {
        new Animal { Id = Guid.NewGuid(), Name = "Billy", Age = 3 },
        new Animal { Id = Guid.NewGuid(), Name = "Milo", Age = 5 },
        new Animal { Id = Guid.NewGuid(), Name = "Jane", Age = 2 }
    };
}
