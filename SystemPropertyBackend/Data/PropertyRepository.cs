using MongoDB.Driver;
using SystemPropertyBackend.Models;

namespace SystemPropertyBackend.Data
{
    // Acceso a datos y consultas
    // Encapsula todas las consultas a la colección properties.
    // Separa la lógica de datos de la API.
    // Facilita testear, reutilizar, y evolucionar filtros sin tocar el endpoint.
    // Mantiene el controlador (endpoint) limpio.

    public class PropertyRepository
    {
        private readonly IMongoContext _ctx;

        public PropertyRepository(IMongoContext ctx) => _ctx = ctx;

        public async Task<List<PropertyDto>> GetFilteredAsync(
            string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            var filter = Builders<Property>.Filter.Empty;
            var filters = new List<FilterDefinition<Property>>();

            if (!string.IsNullOrWhiteSpace(name))
                filters.Add(Builders<Property>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(name, "i")));

            if (!string.IsNullOrWhiteSpace(address))
                filters.Add(Builders<Property>.Filter.Regex(p => p.AddressP, new MongoDB.Bson.BsonRegularExpression(address, "i")));

            if (minPrice.HasValue)
                filters.Add(Builders<Property>.Filter.Gte(p => p.Price, minPrice.Value));

            if (maxPrice.HasValue)
                filters.Add(Builders<Property>.Filter.Lte(p => p.Price, maxPrice.Value));

            if (filters.Count > 0)
                filter = Builders<Property>.Filter.And(filters);

            //var properties = await _ctx.Properties.Find(filter).ToListAsync();
            //cambio para test
            
            //var properties = await _ctx.Properties.Find(filter).ToListAsync();

            var properties = await _ctx.Properties.Find(filter).ToListAsync()
                   ?? new List<Property>();

            var result = new List<PropertyDto>();

            foreach (var prop in properties)
            {
                var owner = await _ctx.Owners.Find(o => o.IdOwner == prop.IdOwner).FirstOrDefaultAsync();
                var image = await _ctx.PropertyImages
                    .Find(img => img.IdProperty == prop.IdProperty && img.Enabled)
                    .FirstOrDefaultAsync();

                result.Add(new PropertyDto(
                    IdOwner: prop.IdOwner,
                    OwnerName: owner?.Name ?? "",
                    Name: prop.Name,
                    AddressP: prop.AddressP,
                    Price: prop.Price,
                    Image: image?.File ?? ""
                ));
            }

            return result;
        }
    }
}
