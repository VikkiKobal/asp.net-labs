using Microsoft.EntityFrameworkCore; 
using CarModels; 

namespace ASPNetExapp.Models 
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; } 
    }
}
