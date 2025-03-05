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

    // Отримати всі машини
    [HttpGet]
    public IActionResult GetCars()
    {
        var cars = _carService.GetCars();
        return Ok(cars);
    }

    // Отримати машину за ID
    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var car = _carService.GetCarById(id);
        return car != null ? Ok(car) : NotFound(new { message = "Car not found" });
    }

    // Додати нову машину
    [HttpPost]
    public IActionResult CreateCar([FromBody] Car newCar)
    {
        // Перевірка на валідність моделі
        if (!ModelState.IsValid)
            return BadRequest(ModelState);  // Повертаємо всі помилки валідації

        try
        {
            var createdCar = _carService.CreateCar(newCar);
            return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    // Оновити машину за ID
    [HttpPatch("{id}")]
    public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
    {
        // Перевірка на валідність моделі
        if (!ModelState.IsValid)
            return BadRequest(ModelState);  // Повертаємо всі помилки валідації

        if (!_carService.UpdateCar(id, updatedCar))
            return NotFound(new { message = "Car not found" });

        return NoContent();
    }

    // Видалити машину за ID
    [HttpDelete("{id}")]
    public IActionResult DeleteCar(int id)
    {
        if (!_carService.DeleteCar(id))
            return NotFound(new { message = "Car not found" });

        return NoContent();
    }
}
