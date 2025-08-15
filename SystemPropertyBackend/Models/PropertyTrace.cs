using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SystemPropertyBackend.Models
{
    public class PropertyTrace
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string IdPropertyTrace { get; set; } = default!;
        public DateTime DateSale { get; set; }
        public string Name { get; set; } = default!;
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public string IdProperty { get; set; } = default!;
    }
}
