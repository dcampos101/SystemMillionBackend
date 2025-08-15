using MongoDB.Bson;

namespace SystemPropertyBackend.Models
{
    //  Data Transfer Object
    // Define qué devuelves al cliente.
    // Limita los campos a los requeridos: IdOwner, Name, AddressProperty, PriceProperty, Image.

    public record PropertyDto(
    ObjectId IdOwner,
    string OwnerName,
    string Name,
    string AddressP,
    decimal Price,
    string Image
    );

}
