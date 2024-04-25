using Helper.ReadBody;
using TaskCamelCase;
using Helper.HttpStatusCodes;
using Helper.Responses;
using Interface.Base;

namespace Middleware.CheckTask;
public class CheckTasks : MiddleBase
{
  private readonly RequestDelegate _next;
  private readonly IBase _base;

  public CheckTasks(RequestDelegate next, MiddleBase middleBase)
  {
    _next = next;
    _base = middleBase;
  }

  public async Task InvokeAsync(HttpContext ctx)
  {
    if (GetPath(ctx) != "/task/new")
    {
      await _next(ctx);
      return;
    }

    var res = ctx.Response;

    ResponseModel asd(string message, int statusCode)
    {
      _base.SetStatusCode(ctx, statusCode);
      return new ResponseBuilder(message, statusCode, new { message, statusCode }).GetResult();
    }

    try
    {
      var body = await ReadBodyInMiddleware<List<Camel>>.Read(ctx);

      var check = CheckObject(body.anyData);


      if (check.httpCode != Codes.Ok)
      {
        _base.SetStatusCode(ctx, Codes.BadRequest);

      }

      await _next(ctx);
      return;
    }
    catch (System.Text.Json.JsonException)
    {
      var err = asd("No se pudo serializar el JSON correctamente", Codes.BadRequest);
      await res.WriteAsJsonAsync(err.anyData);
    }
    catch (System.Exception)
    {
      var err = asd("Error desconocido", Codes.InternalServerError);
      await res.WriteAsJsonAsync(err.anyData);
    }
  }

  public ResponseModel CheckObject(List<Camel> tasks)
  {
    string title;
    string content;
    int important;
    string studentId;
    string teacherId;
    DateTime createAt;
    DateTime limitAt;

    DateTime dateNow = DateTime.Now;

    foreach (Camel task in tasks)
    {
      title = task.title;
      content = task.content;
      important = task.important;
      studentId = task.studentId;
      teacherId = task.teacherId;
      createAt = task.createAt;
      limitAt = task.limitAt;

      int nowIsEqualAtCreateAt = DateTime.Compare(dateNow.Date, createAt.Date);
      int compareCreteAtAndLimitAt = DateTime.Compare(dateNow.Date, limitAt.Date);
      int ifLimitAtIsLess = DateTime.Compare(limitAt, createAt);

      // Validar la fecha de creación
      if (createAt > DateTime.Now)
      {
        return new ResponseBuilder("La fecha de creación de la tarea es mayor que la fecha actual", Codes.BadRequest).GetResult();
      }

      // Validar la fecha límite
      if (limitAt <= createAt)
      {
        return new ResponseBuilder("La fecha de finalización debe ser posterior a la fecha de creación", Codes.BadRequest).GetResult();
      }

      // Validar el formato de las fechas
      if (!DateTime.TryParse(task.createAt.ToString(), out _) || !DateTime.TryParse(task.limitAt.ToString(), out _))
      {
        return new ResponseBuilder("Las fechas no tienen un formato válido", Codes.BadRequest).GetResult();
      }

      // Validar el título y el contenido
      if (string.IsNullOrEmpty(title))
      {
        return new ResponseBuilder("La tarea debe llevar un título", Codes.BadRequest).GetResult();
      }

      if (string.IsNullOrEmpty(content))
      {
        return new ResponseBuilder("La tarea debe contar con contenido", Codes.BadRequest).GetResult();
      }

      // Validar la importancia
      if (important < 0 || important > 1)
      {
        return new ResponseBuilder("La importancia de la tarea debe ser 0 para tareas normales o 1 para tareas de suma importancia", Codes.Ok).GetResult();
      }

      // Validar los IDs
      if (string.IsNullOrEmpty(studentId) || studentId.Length != 36)
      {
        return new ResponseBuilder("El 'studentId' no es correcto, debe tener 36 caracteres", Codes.BadRequest).GetResult();
      }

      if (string.IsNullOrEmpty(teacherId) || teacherId.Length != 36)
      {
        return new ResponseBuilder("El 'teacherId' no es correcto, debe tener 36 caracteres", Codes.BadRequest).GetResult();
      }

    }
    return new ResponseBuilder("La fecha de creación de la tarea es mayor que la fecha actual", Codes.Ok).GetResult();
  }

}
