using Middleware.Base;
using Helper.ReadBody;
using TaskCamelCase;
using System.Globalization;
using Helper.HttpStatusCodes;
using Helper.CompareDateTime;

namespace Middleware.CheckTask;
public class CheckTasks : MiddleBase
{
  private readonly RequestDelegate _next;

  public CheckTasks(RequestDelegate next) { _next = next; }

  public async Task InvokeAsync(HttpContext ctx)
  {
    try
    {
      if (GetPath(ctx) != "/task/new")
      {
        await _next(ctx);
        return;
      }

      var body = await ReadBodyInMiddleware<List<Camel>>.Read(ctx);
      int badRequest = Codes.BadRequest;
      var response = ctx.Response;
      DateTime dateNow = DateTime.Now;

      string title;
      string content;
      int important;
      string studentId;
      string teacherId;
      DateTime createAt;
      DateTime limitAt;

      async void responseAError(int statusCode = 50, string message = "No se proprociono el mensaje")
      {
        response.StatusCode = statusCode;
        await ctx.Response.WriteAsJsonAsync(new { message, statusCode });
      };

      int ToneIsEarlierThanTtwo = -1;
      int ToneIsTheSameAsTtwo = 0;
      int ToneIsLatesThanTtwo = 1;

      foreach (Camel task in body.anyData)
      {
        title = task.title;
        content = task.content;
        important = task.important;
        studentId = task.studentId;
        teacherId = task.teacherId;
        createAt = task.createAt;
        limitAt = task.limitAt;

        System.Console.WriteLine(new
        {
          createAt = Convert.ToDateTime(task.createAt, new CultureInfo("es-AR")).ToString("dd/MM/yyyy"),
          limitAt = Convert.ToDateTime(task.limitAt, new CultureInfo("es-AR"))
        });

        // Comparar
        // DateTime.Compare("t1", "t2")
        // --------
        // if ti >  t2 =  1 - t1 es mayor que t2
        // if t1 <  t2 = -1 - ti es igual que t2
        // if ti == t2 =  0 - t1 es menor que t2
        // --------
        // Por defecto, se compara los dias, meses, años, hs, min, seg, miliseg
        // por ende a cada parámetro ha que añadirle .Date

        // TODO: Crear un programita que compare fechas.
        // - Tiene que ser una clase con dos métodos y estos devuelven bool
        // - El primer método  : si T1 > T2
        // - El segundo método : si T2 > T1

        // Comparar la fecha actual con la que viene de la tarea
        int nowIsEqualAtCreateAt = DateTime.Compare(dateNow.Date, createAt.Date);

        // Comparar la fecha de creación de la tarea y la fecha de finalizacion
        int compareCreteAtAndLimitAt = DateTime.Compare(dateNow.Date, limitAt.Date);

        int ifLimitAtIsLess = DateTime.Compare(limitAt, createAt);

        System.Console.WriteLine("Tuki {0}", CompareIf.A(dateNow.Date, createAt.Date));

        System.Console.WriteLine(nowIsEqualAtCreateAt);
        System.Console.WriteLine(compareCreteAtAndLimitAt);
        System.Console.WriteLine(ifLimitAtIsLess);

        if (!CompareIf.A(dateNow.Date, createAt.Date))
        {
          responseAError(badRequest, "La fecha de creación de la tarea es menor a la de finalizacion");
          return;
        }

        if (compareCreteAtAndLimitAt == ToneIsLatesThanTtwo || compareCreteAtAndLimitAt == ToneIsTheSameAsTtwo)
        {
          responseAError(badRequest, "(._.)");
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
