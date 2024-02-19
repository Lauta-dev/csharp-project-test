using System.Text;
using System.Text.Json;
using System.Net;

namespace CheckNameAndId
{
    class Midd
    {
      private readonly RequestDelegate _next;

      public Midd(RequestDelegate next)
      {
        _next = next;
      }

      async public Task Invoke(HttpContext context)
      {
        var req = context.Request;
        var res = context.Response;
        var path = req.Path;

        if (path.StartsWithSegments("/user/add"))
        {
          req.EnableBuffering();
          var f = new byte[Convert.ToInt32(req.ContentLength)];
          await req.Body.ReadAsync(f, 0, f.Length);
          
          // Get body string here
          string reqContent = Encoding.UTF8.GetString(f);
          Users user = JsonSerializer.Deserialize<Users>(reqContent);
          int id;

          // int.TryParse checkea si `user.id` puede pasar a una valor numérico
          // El `out id` significa que si la conversion es posible para el valor a la variable `id`
          if (!int.TryParse(user.id, out id))
          {
            res.StatusCode = (int)HttpStatusCode.BadRequest;
            await res.WriteAsync("El valor tiene que ser numérico");
            return;
          }

          if (user.id.Length < 1)
          {
            res.StatusCode = (int)HttpStatusCode.BadRequest;
            await res.WriteAsync("El ID tiene que tener un valor");
            return;
          }

          if (user.name.Length < 1)
          {
            res.StatusCode = (int)HttpStatusCode.BadRequest;
            await res.WriteAsync("El nombre tiene que tener un valor");
            return;
          }

          req.Body.Position = 0;
        }

        await _next(context);
      }
    }

    class Users
    {
      public string id { get; set; } = "";
      public string name { get; set; } = "";
    }
}
