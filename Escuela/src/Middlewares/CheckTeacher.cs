using Escuela.Models.TeacherModel;
using Helper.ReadBody;
using Helper.Respo;
using Interface.Base;

namespace Middleware.CheckTeacher;

class CheckTeacherBody
{
  private readonly RequestDelegate _next;
  private readonly IBase _base;

  public CheckTeacherBody(RequestDelegate next, MiddleBase middleBase)
  {
    _next = next;
    _base = middleBase;
  }

  public async Task InvokeAsync(HttpContext ctx)
  {
    if (!_base.GetPath(ctx).Contains("/teacher/new"))
    {
      await _next(ctx);
      return;
    }

    var res = ctx.Response;

    string ifNameIsNull = "Name is null";
    string ifLastNameIsNull = "LastName is null";
    string ifAgeIsAString = "Age is required to be a number";
    string ifClassroomIdIsNull = "ClassroomId is require";
    string ifCheduleIsNull = "Schedule is require";
    string ifSchoolSubjetIsNull = "schoolSubject in require";
    int hsLimit = 13;

    R<TeacherModel[]> bodyToClass = await ReadBodyInMiddleware<TeacherModel[]>.Read(ctx);
    TeacherModel[] teachers = bodyToClass.anyData;

    async void Err(int _statusCode, string message)
    {
      int statusCode = _statusCode;
      _base.SetStatusCode(ctx, statusCode);
      await res.WriteAsJsonAsync(new { message, statusCode });
    }

    foreach (var teacher in teachers)
    {
      if (teacher.Name == null || teacher.Name.Length == 0)
      {
        Err(400, ifNameIsNull);
        return;
      }

      if (teacher.LastName == null || teacher.LastName.Length == 0)
      {
        Err(400, ifLastNameIsNull);
        return;
      }

      if (!int.TryParse(teacher.Age.ToString(), out _))
      {
        Err(400, ifAgeIsAString);
        return;
      }

      if (teacher.ClassroomsId == null || teacher.ClassroomsId.Length == 0)
      {
        Err(400, ifClassroomIdIsNull);
        return;
      }

      if (teacher.SchoolSubject == null || teacher.SchoolSubject.Length == 0)
      {
        Err(400, ifSchoolSubjetIsNull);
        return;
      }

      if (teacher.Schedule.Hour > hsLimit)
      {
        Err(
          400,
          $"El horario del profe ({teacher.Schedule.Hour}) debe ser menor a la hora limite ({hsLimit})"
        );
        return;
      }
    }

    await _next(ctx);
  }
}
