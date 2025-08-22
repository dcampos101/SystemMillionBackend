using MongoDB.Driver;
using SystemPropertyBackend.Models;

namespace SystemPropertyBackend.Data
{
    public interface IMongoContext
    {
        IMongoCollection<Property> Properties { get; }
        IMongoCollection<Owner> Owners { get; }
        IMongoCollection<PropertyImage> PropertyImages { get; }
        IMongoCollection<PropertyTrace> PropertyTraces { get; }
        //IMongoCollection<PropertyDto> PropertyDtos { get; }
    }
}
