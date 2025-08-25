using MongoDB.Driver;
using SystemPropertyBackend.Data;
using SystemPropertyBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.-----
// Registra servicios en Dependency Injection
//string connectionString1 = "mongodb://localhost:27017";

//var validator = new MongoConnectionValidator(connectionString1);
//bool isConnected = await validator.TestConnectionAsync();

//if (!isConnected)
//{
//    // Manejar error o lanzar excepción
//    Console.WriteLine("No se pudo establecer conexión con MongoDB.");
//}

//configurar la conexión a MongoDB.
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("Mongo") ?? "mongodb://localhost:27017";
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("SystemPropertyDB");
});

builder.Services.AddSingleton<IMongoContext, MongoContext>();
builder.Services.AddScoped<PropertyRepository>();
//

// Configura CORS para que el front.
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// ------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// El endpoint recibe query params (name, address, minPrice, maxPrice, page, pageSize, sort, order).
app.UseCors();
app.MapGet("/api/properties", async (
    PropertyRepository repo,
    string? name,
    string? address,
    decimal? minPrice,
    decimal? maxPrice) =>
{
    // Llama a PropertyRepository.GetFilteredAsync(...).
    var properties = await repo.GetFilteredAsync(name, address, minPrice, maxPrice);
    return Results.Ok(properties);
});
//

app.Run();
