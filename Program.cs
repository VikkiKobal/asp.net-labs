using ASPNetExapp.Models; 
using CarServices;
using Microsoft.EntityFrameworkCore; 


var builder = WebApplication.CreateBuilder(args);

// Register DbContext with scoped lifetime
builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register CarService with scoped lifetime
builder.Services.AddScoped<CarService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
