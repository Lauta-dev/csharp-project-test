using GetUserForId;
using ReturnAllUsers;
using AddUser;
using UpdateUserInfo;
using DeleteUserFromDB;
using LoadUser;

namespace StartApp
{
  class App
  {
    public static void StartServer()
    {
      var builder = WebApplication.CreateBuilder();
      string corsPolicyName = "Habilitar cors";

      // Habilitar Cors
      // TODO: Seguir leyendo
      // https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0
      builder.Services.AddCors(opts => 
      {
        opts.AddPolicy(name: corsPolicyName,
          policy =>
          {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
          }
        );
      });

      CreateUser.Loaded();

      WebApplication app = builder.Build();
      app.UseCors(corsPolicyName);

      // Obtener usuario por ID
      app.MapGet("/user/{id}", P.GetUser);
     
      // Obtener todos los usuarios
      app.MapGet("/users", UserCollection.GetAllUsers);
      
      // Agregar un nuevo usuario
      app.MapPost("/user/add", AddUserInDB.add);

      // Actualizar información del usuario
      app.MapPatch("/user/update/{id}", User.Update);

      // Eliminar un usuario
      app.MapDelete("/user/delete/{id}", DeleteUser.Delete);

      app.Run();
    }
  }
}
