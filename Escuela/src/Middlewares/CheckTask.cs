using Middleware.Base;
using Helper.ReadBody;
using TaskCamelCase;
using System.Globalization;
using Helper.HttpStatusCodes;

namespace Middleware.CheckTask;
public class Check : MiddleBase
{
  private readonly RequestDelegate _next;

  public Check(RequestDelegate next) { _next = next; }

  public async Task InvokeAsync(HttpContext ctx)
  {
    try
    {
      if (GetMethod(ctx) != HttpMethods.Post && GetPath(ctx) != "/task/new")
      {
        await _next(ctx);
        return;
      }

      var body = await ReadBodyInMiddleware<List<Camel>>.Read(ctx);
      int badRequest = Codes.BadRequest;
      var response = ctx.Response;

      string title;
      string content;
      int important;
      string studentId;
      string teacherId;

      async void responseAError(int statusCode = 50, string message = "No se proprociono el mensaje")
      {
        response.StatusCode = statusCode;
        await ctx.Response.WriteAsJsonAsync(new { message, statusCode });
      };

      foreach (Camel task in body.anyData)
      {
        title = task.title;
        content = task.content;
        important = task.important;
        studentId = task.studentId;
        teacherId = task.teacherId;
        DateTime dateNow = DateTime.Now;

        // TODO: Verificar que la hora sea correcta
        System.Console.WriteLine(new
        {
          createAt = Convert.ToDateTime(task.createAt, new CultureInfo("es-AR")).ToString("dd/MM/yyyy"),
          limitAt = Convert.ToDateTime(task.limitAt, new CultureInfo("es-AR"))
        });

        // Comparar
        // DateTime.Compare("t1", "t2")
        // --------
        // si ti >  t2 =  1
        // si t1 <  t2 = -1
        // si ti == t2 =  0

        // t1 == t2 = 0
        int nowIsEqualAtCreateAt = DateTime.Compare(dateNow.Date, task.createAt.Date);
        string f = "dd/MM/yyyy";

        System.Console.WriteLine(nowIsEqualAtCreateAt);

        if (nowIsEqualAtCreateAt == 1)
        {
          responseAError(badRequest, "No se puede asignar una tarea con una fecha pasada");
          return;
        }

        if (!DateTime.TryParse(task.createAt.ToString(), out _))
        {
          responseAError(badRequest, "La fecha de inicio no tiene el formato valido");
          return;
        }

         if (!DateTime.TryParse(task.limitAt.ToString(), out _))
        {
          responseAError(badRequest, "La fecha de inicio no tiene el formato valido");
          return;
        }

        if (title.Length < 1 || title == null)
        {
          responseAError(badRequest, "La tarea debe llevar un titulo");
          return;
        }

        if (content.Length < 1 || content == null)
        {
          responseAError(badRequest, "La tarea debe contar con el contenido de la misma");
          return;
        }

        if (important > 1)
        {
          responseAError(badRequest, "La tarea debe contar con la importancia. 0 para tareas normales, 1 para tareas de suma importancia");
          return;
        }

        if (studentId.Length != 36 || studentId == null)
        {
          responseAError(badRequest, "El 'studentId' no es correcto, debe ser de 36 de largo");
          return;
        }

        if (teacherId.Length != 36 || teacherId == null)
        {
          responseAError(badRequest, "El 'teachertId' no es correcto, debe ser de 36 de largo");
          return;
        }
      }

      await response.WriteAsJsonAsync(body.anyData);
      return;
    }
    catch (System.Text.Json.JsonException ex)
    {
      Exceptions(ex, ctx, 400, "No se pudo serializar el JSON correctamente");
    }
    catch (System.Exception ex)
    {
      Exceptions(ex, ctx, 500, "Error desconocido");
    }
  }
}
