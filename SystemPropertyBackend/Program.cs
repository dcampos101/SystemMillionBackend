using SystemPropertyBackend.Models;
using SystemPropertyBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.-----
// Registra servicios en Dependency Injection
builder.Services.AddSingleton<MongoContext>();
builder.Services.AddScoped<PropertyRepository>();
//

// Configura CORS para que el front (p. ej., Next.js) pueda llamar a la API.
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

// add  Configura CORS para que el front (p. ej., Next.js) pueda llamar a la API.
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
