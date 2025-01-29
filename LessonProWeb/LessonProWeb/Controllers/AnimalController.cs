using LessonProWeb.Models;
using LessonProWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace LessonProWeb.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController : ControllerBase
{
    private readonly AnimalService _service = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllAnimals());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var animal = _service.GetAnimalById(id);
        return animal is not null ? Ok(animal) : NotFound();
    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        animal.Id = Guid.NewGuid();
        {
            _service.AddAnimal(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Animal animal)
    {
        if (id != animal.Id) return BadRequest();
        _service.UpdateAnimal(animal);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _service.DeleteAnimal(id);
        return NoContent();
    }
}

