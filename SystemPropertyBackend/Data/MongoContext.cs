using MongoDB.Driver;
using SystemPropertyBackend.Models;

namespace SystemPropertyBackend.Data
{
    //Conexión a la BD
    //Centraliza la conexión a MongoDB.
    //Permite cambiar el nombre de la base o la colección en un solo lugar.
    //Se registra como Singleton (cliente Mongo es thread-safe y recomendado reutilizar).
    public class MongoContext
    {
        public IMongoDatabase Db { get; }

        public MongoContext(IConfiguration config)
        {
            //Lee la cadena de conexión desde appsettings.json o variables de entorno.
            var connectionString = config.GetConnectionString("Mongo") ?? "mongodb://localhost:27017";
            var databaseName = config["MongoDatabase"] ?? "SystemPropertyDB";
            //Crea el MongoClient y expone el IMongoDatabase.
            var client = new MongoClient(connectionString);
            Db = client.GetDatabase(databaseName);
        }

        //Provee la colección tipada: IMongoCollection<Property> Properties.
        public IMongoCollection<Owner> Owners => Db.GetCollection<Owner>("Owner");
        public IMongoCollection<Property> Properties => Db.GetCollection<Property>("Property");
        public IMongoCollection<PropertyImage> PropertyImages => Db.GetCollection<PropertyImage>("PropertyImage");
        public IMongoCollection<PropertyTrace> PropertyTraces => Db.GetCollection<PropertyTrace>("PropertyTrace");

    }
}
