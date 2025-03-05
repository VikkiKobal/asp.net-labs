using ASPNetExapp.Services;

var builder = WebApplication.CreateBuilder(args);

// Додаємо підтримку контролерів
builder.Services.AddControllers();

// Додаємо підтримку Swagger
builder.Services.AddSwaggerGen();

// Додаємо кастомні сервіси
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<CarService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Важливо для роботи контролерів! Це по суті налаштування маршрутизації

app.Run();
