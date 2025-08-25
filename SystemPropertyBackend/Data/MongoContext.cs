using MongoDB.Driver;
using SystemPropertyBackend.Models;

namespace SystemPropertyBackend.Data
{
    public class MongoContext : IMongoContext
    {
            public IMongoCollection<Property> Properties { get; }
            public IMongoCollection<Owner> Owners { get; }
            public IMongoCollection<PropertyImage> PropertyImages { get; }
            public IMongoCollection<PropertyTrace> PropertyTraces { get; }

            public MongoContext(IMongoDatabase database)
            {
                Properties = database.GetCollection<Property>("Property");
                Owners = database.GetCollection<Owner>("Owner");
                PropertyImages = database.GetCollection<PropertyImage>("PropertyImage");
                PropertyTraces = database.GetCollection<PropertyTrace>("PropertyTrace");
            }

    }
}
