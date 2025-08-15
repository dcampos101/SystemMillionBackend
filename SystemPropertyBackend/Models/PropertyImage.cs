using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SystemPropertyBackend.Models
{
    public class PropertyImage
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string IdPropertyImage { get; set; } = default!;
        public ObjectId IdProperty { get; set; } = default!;
        public string File { get; set; } = default!;
        public bool Enabled { get; set; }
    }
}
