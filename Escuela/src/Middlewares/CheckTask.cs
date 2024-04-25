using Helper.ReadBody;
using TaskCamelCase;
using Helper.HttpStatusCodes;
using Helper.Responses;
using Interface.Base;
using Middleware.Error;

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

    ResponseModel GenerateResponseModel(string message, int statusCode)
    {
      _base.SetStatusCode(ctx, statusCode);
      return new ResponseBuilder(
        message,
        statusCode,
        new
        {
          message,
          statusCode
        }
      ).GetResult();
    }

    try
    {
      var body = await ReadBodyInMiddleware<List<Camel>>.Read(ctx);

      var check = CheckObject(body.anyData);

      if (check.httpCode != Codes.Ok)
      {
        var err = GenerateResponseModel(check.comment, Codes.BadRequest);
        await res.WriteAsJsonAsync(err.anyData);

        return;
      }

      await _next(ctx);
      return;
    }
    catch (System.Text.Json.JsonException)
    {
      var err = GenerateResponseModel("No se pudo serializar el JSON correctamente", Codes.BadRequest);
      await res.WriteAsJsonAsync(err.anyData);
    }
    catch (System.Exception)
    {
      var err = GenerateResponseModel("Error desconocido", Codes.InternalServerError);
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
        return new ResponseBuilder(ErrorsMessage.CreateAtIsMoreThenNow, Codes.BadRequest).GetResult();
      }

      // Validar la fecha límite
      if (limitAt <= createAt)
      {
        return new ResponseBuilder(ErrorsMessage.LimitAtIsLessThenCreateAt, Codes.BadRequest).GetResult();
      }

      // Validar el formato de las fechas
      if (!DateTime.TryParse(task.createAt.ToString(), out _) || !DateTime.TryParse(task.limitAt.ToString(), out _))
      {
        return new ResponseBuilder(ErrorsMessage.DateTimeIsInvalit, Codes.BadRequest).GetResult();
      }

      // Validar el título y el contenido
      if (string.IsNullOrEmpty(title))
      {
        return new ResponseBuilder(ErrorsMessage.TitleIsNullOrEmpry, Codes.BadRequest).GetResult();
      }

      if (string.IsNullOrEmpty(content))
      {
        return new ResponseBuilder(ErrorsMessage.ContentIsNullOrEmply, Codes.BadRequest).GetResult();
      }

      // Validar la importancia
      if (important < 0 || important > 1)
      {
        return new ResponseBuilder(ErrorsMessage.Important, Codes.Ok).GetResult();
      }

      // Validar los IDs
      if (string.IsNullOrEmpty(studentId) || studentId.Length != 36)
      {
        return new ResponseBuilder(ErrorsMessage.StudentIdIsNullOrEmply, Codes.BadRequest).GetResult();
      }

      if (string.IsNullOrEmpty(teacherId) || teacherId.Length != 36)
      {
        return new ResponseBuilder(ErrorsMessage.TeacherIdIsNullOrEmply, Codes.BadRequest).GetResult();
      }
    }

    return new ResponseBuilder(ErrorsMessage.Ok, Codes.Ok).GetResult();
  }

}
