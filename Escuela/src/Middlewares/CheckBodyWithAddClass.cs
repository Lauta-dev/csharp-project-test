using Middleware.Base;
using Helper.ReadBody;
using Escuela.Models.Aulas;
using Helper.Respo;
using Helper.HttpStatusCodes;
using Interface.Base;
using Middleware.CheckBody;

namespace Middleware.CheckBodyBeforeAddClassroom;
public class CheckClassrooms
{
  private readonly RequestDelegate _next;
  private readonly IBase _base;

  public CheckClassrooms(RequestDelegate next, MiddleBase middleBase)
  {
    _next = next;
    _base = middleBase;
  }

  public async Task InvokeAsync(HttpContext ctx)
  {
    var res = ctx.Response;
    int NotAcceptable = Codes.NotAcceptable;

    if (_base.GetPath(ctx) != "/classroom/new")
    {
      await _next(ctx);
      return;
    }

    try
    {
      R<Classrooms[]> bodyToClass = await ReadBodyInMiddleware<Classrooms[]>.Read(ctx);
      Classrooms[] classrooms = bodyToClass.anyData;

      var data = new CheckBody.CheckBody().Check(classrooms);

      if (data.httpCode != 200)
      {
        _base.SetStatusCode(ctx, data.httpCode);
        await res.WriteAsJsonAsync(data.anyData);
        return;
      }

      await _next(ctx);
    }
    catch (System.Text.Json.JsonException ex)
    {
      System.Console.WriteLine(ex);
      _base.SetStatusCode(ctx, 400);
      await res.WriteAsJsonAsync(new { NotAcceptable, message = "No se pudo convertir el valor a string" });
      return;
    }
    catch (System.InvalidOperationException ex)
    {
      System.Console.WriteLine(ex);
      _base.SetStatusCode(ctx, 400);
      await res.WriteAsJsonAsync(new { NotAcceptable, message = "Operación invalida" });
    }
    catch (System.Exception ex)
    {
      System.Console.WriteLine(ex);
      _base.SetStatusCode(ctx, 500);
      await res.WriteAsJsonAsync(new { NotAcceptable, message = "Error del servidor" });
    };
  }
}

