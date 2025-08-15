using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SystemPropertyBackend.Models
{
    public class Owner
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public ObjectId IdOwner { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string AddressO { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public DateTime Birthday { get; set; }
    }
}
