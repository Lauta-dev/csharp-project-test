using Microsoft.AspNetCore.Mvc;
using CheckNameAndId;
using FormatJson;
using System.Net;

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

      WebApplication app = builder.Build();

      List<User> users = new List<User>();
      users.Add(new User("1", "Dante"));
      users.Add(new User("2", "Ezio"));
      users.Add(new User("3", "Kratos"));

      app.UseCors(corsPolicyName);
      
      app.UseMiddleware<Midd>();

      app.MapGet("/user/{id}", (string id) => 
      {
        if (!int.TryParse(id, out int idParse))
        {
          // TODO: Entender que hace (int)
          int errorCode = (int)HttpStatusCode.BadRequest;
          return new Error(errorCode, "El id tiene que ser un número").GetErrorsInJson();
        }
  
        if (users.Count < 1)
        {
          int errorCode = (int)HttpStatusCode.BadRequest;
          return new Error(errorCode, "El id tiene que ser un número").GetErrorsInJson();
        }

        var user = users.Find(e => e.id == id);
        
        if (user is null)
        {
          int errorCode = (int)HttpStatusCode.BadRequest;
          return new Error(errorCode, "El id tiene que ser un número").GetErrorsInJson();
        }

        string json = FormatJsonSerializer.Format(user);

        return json;

      });

      app.MapGet("/users", () => 
      {
        if (users.Count < 1)
        {
          int errorCode = (int)HttpStatusCode.NoContent;
          var error = new Error(errorCode, "No hay usuarios"); 
          return error.GetErrorsInJson();
        }

        return FormatJsonSerializer.Format(users);
      });

      app.MapPost("/user/add", ([FromBody] Users body) => 
      {
        User user = new User(body.id, body.name);
        users.Add(user);
        return $"El usuario {body.name} fue añadido con exito";        
      });

      app.MapPatch("/user/update/{id}", () =>
      {

      });

      app.MapDelete("/user/delete", () =>
      {

      });

      app.Run();
    }

    class User : Users
    {
      public User(string userId, string userName)
      {
        id = userId;
        name = userName;
      }
    }

    class Error
    {
      public int ErrorCode { get; set; }
      public string ErrorMessage { get; set; }

      public Error(int errorCode, string errorMessage)
      {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
      }

      public string GetErrorsInJson()
      {
        // FIX: Ya me devuelve un el objeto correcto
        var error = FormatJsonSerializer.Format(this);
        return error;
      }
    }
  }
 
}
