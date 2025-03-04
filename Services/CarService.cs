using ASPNetExapp.Models;

namespace ASPNetExapp.Services;

public class CarService
{
    private readonly List<Car> _cars = new()
    {
        new Car { Id = 1, Number = "AA1234BB", Year = 2020, Brand = "Toyota", Color = "Red", Condition = "New", OwnerLastName = "Shevchenko", Address = "Kyiv" },
        new Car { Id = 2, Number = "BC5678CD", Year = 2018, Brand = "Honda", Color = "Blue", Condition = "Used", OwnerLastName = "Petrenko", Address = "Lviv" }
    };

    public List<Car> GetCars() => _cars;

    public Car? GetCarById(int id) => _cars.FirstOrDefault(c => c.Id == id);

    public Car CreateCar(Car newCar)
    {
        newCar.Id = _cars.Count > 0 ? _cars.Max(c => c.Id) + 1 : 1;
        _cars.Add(newCar);
        return newCar;
    }

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

    public bool DeleteCar(int id)
    {
        var car = GetCarById(id);
        if (car == null) return false;

        _cars.Remove(car);
        return true;
    }
}
