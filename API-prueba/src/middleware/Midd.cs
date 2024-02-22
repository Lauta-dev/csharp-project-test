using System.Text;
using System.Text.Json;
using Users;

namespace CheckNameAndId
{
    class Midd
    {
      private readonly RequestDelegate _next;

      public Midd(RequestDelegate next)
      {
        _next = next;
      }

      // TODO: Leer más sobre `Task Invoke`
      async public Task Invoke(HttpContext context)
      {
        var req = context.Request;
        var res = context.Response;
        var path = req.Path;

        if (path.StartsWithSegments("/user/add"))
        {
          try
          {
            req.EnableBuffering();
            var f = new byte[Convert.ToInt32(req.ContentLength)];
            await req.Body.ReadAsync(f, 0, f.Length);
            
            // Get body string here
            string reqContent = Encoding.UTF8.GetString(f);
            User user = JsonSerializer.Deserialize<User>(reqContent);

            if (user.name.Length < 1)
            {
              res.StatusCode = 404;
              await res.WriteAsync("No puede registrar un usuario sin nombre");
              return;
            }

            req.Body.Position = 0;    
          }
          catch(NullReferenceException nr)
          {
            System.Console.WriteLine($"error: \n\n{nr.Message}");
          }
          catch (System.Exception)
          {
          }
          
          
        }

        await _next(context);
      }
    }

}
