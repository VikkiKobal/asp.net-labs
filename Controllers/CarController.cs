using Microsoft.AspNetCore.Mvc;
using ASPNetExapp.Models;
using ASPNetExapp.Services;

namespace CarsApi.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly CarService _carService;

        public CarsController(CarService carService)
        {
            _carService = carService;
        }

        // Get all cars
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carService.GetCars();
            return Ok(cars);
        }

        // Get car by ID
        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carService.GetCarById(id);
            return car != null ? Ok(car) : NotFound(new { message = "Car not found" });
        }

        // Create a new car
        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] Car newCar)
        {
            try
            {
                var createdCar = _carService.CreateCar(newCar);
                return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update car by ID
        [HttpPatch("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carService.UpdateCar(id, updatedCar))
                return NotFound(new { message = "Car not found" });

            return NoContent();
        }

        // Delete car by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            if (!_carService.DeleteCar(id))
                return NotFound(new { message = "Car not found" });

            return NoContent();
        }
    }
}
