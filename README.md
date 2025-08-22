# PropertyRepository

Repositorio que contiene la implementación de acceso a datos para entidades de tipo `Property`, utilizando MongoDB como base de datos, para el proyecto Million.
## Tecnologías Utilizadas

- C# 
- MongoDB.Driver
- MongoDB (Base de datos)
- Visual Studio
Configura la cadena de conexión a MongoDB en appsettings.json:
{
  "MongoDb": {
    "ConnectionString": "mongodb://localhost:27017",
    "Database": "InmobiliariaDB"
  }
}

En la carpeta BD, se encuentran los script iniciales para la base de datos en mongo y la informacion en JSON de las tablas utilizadas. 

Cargue de servicio con swagger:
<img width="921" height="494" alt="image" src="https://github.com/user-attachments/assets/f02ff5ff-764d-4045-a1a7-a6e17e579518" />
<img width="921" height="491" alt="image" src="https://github.com/user-attachments/assets/5f5a930b-d4ca-4ecd-ad01-0509bfccd2a8" />

Utilizando filtros: 
<img width="921" height="480" alt="image" src="https://github.com/user-attachments/assets/080a851f-7ed9-471e-a427-3d6797f660dd" />
<img width="921" height="468" alt="image" src="https://github.com/user-attachments/assets/f08fe092-5373-4c79-9ae1-333f27f252e0" />
