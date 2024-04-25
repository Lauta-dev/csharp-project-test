# Doc

## Estructura de carpetas

| Path                              | Que es                                    |
|-----------------------------------|-------------------------------------------|
| ./src/                            | Código fuente                             |
| ./src/main.cs                     | Ejecución del programa                    |
| ./src/Rauts.cs                    | Rutas                                     |
| ./src/SchoolCtx.cs                | Configuración de la base de datos         |
| ./src/ConfigurationServices.cs    | Configuración de los servicios            |
| ./src/di/                         | Dependency Injection                      |
| ./src/helper/                     | Código que me ayuda en algo expecifico    |
| ./src/entitys/                    | Estructura de las tablas                  |
| ./src/Controllers/                | Todos los enpoint                         |
| ./src/Middlewares/                | Verificaciones                            |
| ./src/model/                      | Funcionalidad                             |


- Path: `/teacher/delete`
- Method: **DELETE**
- Desc: Esta ruta se encarga de eliminar los profesores.
    Se le tiene que pasar un **Query Param** (?id=) con este formato: 123,123,123. Ejemplo:

```url
/teacher/delete?id=123,123,123,123
```

