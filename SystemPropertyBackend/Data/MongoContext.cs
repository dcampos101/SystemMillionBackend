using MongoDB.Driver;
using SystemPropertyBackend.Models;

namespace SystemPropertyBackend.Data
{
    //Conexión a la BD
    //Centraliza la conexión a MongoDB.
    //Permite cambiar el nombre de la base o la colección en un solo lugar.
    //Se registra como Singleton (cliente Mongo es thread-safe y recomendado reutilizar).
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

        //public IMongoDatabase Db { get; }
        ////public MongoContext() { } // constructor sin parámetros para UnitTest


        //public MongoContext(IConfiguration config)
        //{
        //    //Lee la cadena de conexión desde appsettings.json o variables de entorno.
        //    var connectionString = config.GetConnectionString("Mongo") ?? "mongodb://localhost:27017";
        //    var databaseName = config["MongoDatabase"] ?? "SystemPropertyDB";
        //    //Crea el MongoClient y expone el IMongoDatabase.
        //    var client = new MongoClient(connectionString);
        //    Db = client.GetDatabase(databaseName);
        //}

        //Provee la colección tipada: IMongoCollection<Property> Properties.
        //public IMongoCollection<Owner> Owners => Db.GetCollection<Owner>("Owner");
        //public IMongoCollection<Property> Properties => Db.GetCollection<Property>("Property");
        //public IMongoCollection<PropertyImage> PropertyImages => Db.GetCollection<PropertyImage>("PropertyImage");
        //public IMongoCollection<PropertyTrace> PropertyTraces => Db.GetCollection<PropertyTrace>("PropertyTrace");

        //UnitTest: Provee colecciones mockeadas para pruebas unitarias.
        //public virtual IMongoCollection<Owner> Owners => Db.GetCollection<Owner>("Owner")!;
        //public virtual IMongoCollection<Property> Properties => Db.GetCollection<Property>("Property")!;
        //public virtual IMongoCollection<PropertyImage> PropertyImages => Db.GetCollection<PropertyImage>("PropertyImage")!;

        //public class MongoContext : IMongoContext
        //{
        //public IMongoCollection<Property> Properties { get; }
        //public IMongoCollection<Owner> Owners { get; }
        //public IMongoCollection<PropertyImage> PropertyImages { get; }

        //public MongoContext(IMongoDatabase database)
        //{
        //    Properties = database.GetCollection<Property>("properties");
        //    Owners = database.GetCollection<Owner>("owners");
        //    PropertyImages = database.GetCollection<PropertyImage>("propertyImages");
        //}
        //}
    }
    //public class MongoConnectionValidator
    //{
    //    private readonly string _connectionString;

    //    public MongoConnectionValidator(string connectionString)
    //    {
    //        _connectionString = connectionString;
    //    }

    //    public async Task<bool> TestConnectionAsync()
    //    {
    //        try
    //        {
    //            var client = new MongoClient(_connectionString);

    //            // Intentar obtener la lista de bases de datos como prueba de conectividad
    //            await client.ListDatabaseNamesAsync();

    //            Console.WriteLine("Conexión exitosa a MongoDB.");
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error al conectar a MongoDB: {ex.Message}");
    //            return false;
    //        }
    //    }
    //}
}
