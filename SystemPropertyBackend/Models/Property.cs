using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SystemPropertyBackend.Models
{
    // Modelo de dominio
    // Define cómo luce un Property dentro de tu aplicación y en MongoDB.
    // Incluye atributos de Mongo ([BsonId], BsonRepresentation) para mapear el _id.

    public class Property
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public ObjectId IdProperty { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string AddressP { get; set; } = default!;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = default!;
        public int Year { get; set; }
        public ObjectId IdOwner { get; set; } = default!;
    }
}
