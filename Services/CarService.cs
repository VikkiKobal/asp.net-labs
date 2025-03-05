using ASPNetExapp.Models;

namespace ASPNetExapp.Services;

public class CarService
{
    private readonly List<Car> _cars = new()
    {
        new Car { Id = 1, Number = "AA1234BB", Year = 2020, Brand = "Toyota", Color = "Red", Condition = "New", OwnerLastName = "Shevchenko", Address = "Kyiv" },
        new Car { Id = 2, Number = "BC5678CD", Year = 2018, Brand = "Honda", Color = "Blue", Condition = "Used", OwnerLastName = "Petrenko", Address = "Lviv" },
        new Car { Id = 3, Number = "CE9012DE", Year = 2015, Brand = "Ford", Color = "Black", Condition = "Used", OwnerLastName = "Koval", Address = "Odesa" },
        new Car { Id = 4, Number = "DA3456EF", Year = 2022, Brand = "BMW", Color = "White", Condition = "New", OwnerLastName = "Ivanenko", Address = "Dnipro" },
        new Car { Id = 5, Number = "CE9012DE", Year = 2015, Brand = "Ford", Color = "Black", Condition = "Used", OwnerLastName = "Koval", Address = "Odesa" }
    };

    // Get all cars
    public List<Car> GetCars() => _cars;

    // Get car by ID
    public Car? GetCarById(int id) => _cars.FirstOrDefault(c => c.Id == id);

    // Add a new car
    public Car CreateCar(Car newCar)
    {
        if (_cars.Any(c => c.Number == newCar.Number))
        {
            throw new InvalidOperationException("Car with this number already exists.");
        }

        newCar.Id = _cars.Any() ? _cars.Max(c => c.Id) + 1 : 1;
        _cars.Add(newCar);
        return newCar;
    }

    // Update car by ID
    public bool UpdateCar(int id, Car updatedCar)
    {
        var car = GetCarById(id);
        if (car == null) return false;

        car.Number = updatedCar.Number;
        car.Year = updatedCar.Year;
        car.Brand = updatedCar.Brand;
        car.Color = updatedCar.Color;
        car.Condition = updatedCar.Condition;
        car.OwnerLastName = updatedCar.OwnerLastName;
        car.Address = updatedCar.Address;
        return true;
    }

    // Delete car by ID
    public bool DeleteCar(int id)
    {
        var car = GetCarById(id);
        if (car == null) return false;

        _cars.Remove(car);
        return true;
    }
}
