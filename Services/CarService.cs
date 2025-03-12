using CarModels; 
using Microsoft.EntityFrameworkCore;
using ASPNetExapp.Models; 


namespace CarServices
{
    public class CarService
    {
        private readonly CarDbContext _context;

        public CarService(CarDbContext context)
        {
            _context = context;
        }

        // Get all cars
        public async Task<List<Car>> GetCars() => await _context.Cars.ToListAsync();

        // Get car by ID
        public async Task<Car?> GetCarById(int id) => await _context.Cars
            .FirstOrDefaultAsync(c => c.Id == id);

        // Add a new car
        public async Task<Car> CreateCar(Car newCar)
        {
            if (await _context.Cars.AnyAsync(c => c.Number == newCar.Number))
            {
                throw new InvalidOperationException("Car with this number already exists.");
            }

            _context.Cars.Add(newCar);
            await _context.SaveChangesAsync();
            return newCar;
        }

        // Update car by ID
        public async Task<bool> UpdateCar(int id, Car updatedCar)
        {
            var car = await GetCarById(id);
            if (car == null) return false;

            car.Number = updatedCar.Number ?? car.Number;
            car.Year = updatedCar.Year;
            car.Brand = updatedCar.Brand ?? car.Brand;
            car.Color = updatedCar.Color ?? car.Color;
            car.Condition = updatedCar.Condition ?? car.Condition;
            car.OwnerLastName = updatedCar.OwnerLastName ?? car.OwnerLastName;
            car.Address = updatedCar.Address ?? car.Address;

            await _context.SaveChangesAsync();
            return true;
        }

        // Delete car by ID
        public async Task<bool> DeleteCar(int id)
        {
            var car = await GetCarById(id);
            if (car == null) return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
