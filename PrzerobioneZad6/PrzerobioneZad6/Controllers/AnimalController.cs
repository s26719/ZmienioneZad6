using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PrzerobioneZad6.Models;
using PrzerobioneZad6.Repositories;
using PrzerobioneZad6.Services;



namespace PrzerobioneZad6.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController : ControllerBase
{
    private readonly AnimalsService _animalsService;

    public AnimalController(AnimalsService animalsService)
    {
        _animalsService = animalsService;
    }


    [HttpGet]
    public ActionResult<List<Animal>> GetAnimals([FromQuery] string orderBy = "name")
    {
        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public ActionResult AddAnimal([FromBody] Animal animal)
    {
        _animalsService.AddAnimal(animal);
        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateAnimal(int id, [FromBody] Animal animal)
    {
        if (id != animal.IdAnimal)
        {
            return BadRequest("Id does not exist");
        }
        _animalsService.UpdateAnimal(animal);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {
        _animalsService.DeleteAnimal(id);
        return Ok();
    }
}