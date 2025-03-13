using Microsoft.EntityFrameworkCore;
using CarModels;

namespace ASPNetExapp.Models
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Number = "AA1234BB", Year = 2015, Brand = "Toyota", Color = "Red", Condition = "Good", OwnerLastName = "Smith", Address = "123 Main St" },
                new Car { Id = 2, Number = "BB5678CC", Year = 2020, Brand = "Honda", Color = "Blue", Condition = "Excellent", OwnerLastName = "Johnson", Address = "456 Oak Ave" },
                new Car { Id = 3, Number = "CC9101DD", Year = 2018, Brand = "Ford", Color = "Black", Condition = "Fair", OwnerLastName = "Brown", Address = "789 Pine Rd" },
                new Car { Id = 4, Number = "DD1122EE", Year = 2022, Brand = "BMW", Color = "White", Condition = "New", OwnerLastName = "Davis", Address = "101 Elm St" }
            );
        }
    }
}
