using Microsoft.AspNetCore.Mvc; 
using CarModels; 
using CarServices; 
namespace CarControllers
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
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carService.GetCars();
            return Ok(cars);
        }

        // Get car by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetCarById(id);
            return car != null ? Ok(car) : NotFound(new { message = "Car not found" });
        }

        // Create a new car
        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar([FromBody] Car newCar)
        {
            try
            {
                var createdCar = await _carService.CreateCar(newCar);
                return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update car by ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car updatedCar)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _carService.UpdateCar(id, updatedCar))
                return NotFound(new { message = "Car not found" });

            return NoContent();
        }

        // Delete car by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (!await _carService.DeleteCar(id))
                return NotFound(new { message = "Car not found" });

            return NoContent();
        }
    }
}
