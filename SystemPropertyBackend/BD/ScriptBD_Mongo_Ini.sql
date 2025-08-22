//Script para poblar BD mongo

use SystemPropertyDB;

// Limpieza previa
db.Owner.deleteMany({});
db.Property.deleteMany({});
db.PropertyImage.deleteMany({});
db.PropertyTrace.deleteMany({});

const owner1Id = ObjectId();
const owner2Id = ObjectId();

db.Owner.insertMany([
  {
    _id: owner1Id,
    Name: "Juan Pérez",
    AddressO: "Calle 123 #45-67, Bogotá",
    Photo: "https://example.com/owner1.jpg",
    Birthday: ISODate("1980-05-10")
  },
  {
    _id: owner2Id,
    Name: "María Gómez",
    AddressO: "Av. Siempre Viva 742, Medellín",
    Photo: "https://example.com/owner2.jpg",
    Birthday: ISODate("1975-09-22")
  }
]);

const prop1Id = ObjectId();
const prop2Id = ObjectId();

db.Property.insertMany([
  {
    _id: prop1Id,
    Name: "Apartamento Central Park",
    AddressP: "Cra 10 #20-30, Bogotá",
    Price: 350000000,
    CodeInternal: "CP-2025",
    Year: 2010,
    IdOwner: owner1Id
  },
  {
    _id: prop2Id,
    Name: "Casa Campestre",
    AddressP: "Km 15 vía Rionegro, Medellín",
    Price: 850000000,
    CodeInternal: "CC-2025",
    Year: 2015,
    IdOwner: owner2Id
  }
]);

db.PropertyImage.insertMany([
  {
    _id: ObjectId(),
    IdProperty: prop1Id,
    File: "https://example.com/prop1_img1.jpg",
    Enabled: true
  },
  {
    _id: ObjectId(),
    IdProperty: prop1Id,
    File: "https://example.com/prop1_img2.jpg",
    Enabled: false
  },
  {
    _id: ObjectId(),
    IdProperty: prop2Id,
    File: "https://example.com/prop2_img1.jpg",
    Enabled: true
  }
]);

db.PropertyTrace.insertMany([
  {
    _id: ObjectId(),
    DateSale: ISODate("2020-03-15"),
    Name: "Venta inicial",
    Value: 340000000,
    Tax: 10000000,
    IdProperty: prop1Id
  },
  {
    _id: ObjectId(),
    DateSale: ISODate("2023-07-20"),
    Name: "Reventa",
    Value: 850000000,
    Tax: 25000000,
    IdProperty: prop2Id
  }
]);
