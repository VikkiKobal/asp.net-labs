using Microsoft.AspNetCore.Mvc;
using ASPNetExapp.Models;
using ASPNetExapp.Services;

namespace UsersApi.Controllers;

[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
    private readonly CarService _carService;

    public CarsController(CarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetCars()
    {
        return Ok(_carService.GetCars());
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
        var car = _carService.GetCarById(id);
        return car != null ? Ok(car) : NotFound(new { message = "Car not found" });
    }

    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car newCar)
    {
        var createdCar = _carService.CreateCar(newCar);
        return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
    }

    [HttpPatch("{id}")]
    public ActionResult UpdateCar(int id, [FromBody] Car updatedCar)
    {
        if (!_carService.UpdateCar(id, updatedCar))
            return NotFound(new { message = "Car not found" });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCar(int id)
    {
        if (!_carService.DeleteCar(id))
            return NotFound(new { message = "Car not found" });

        return NoContent();
    }
}
