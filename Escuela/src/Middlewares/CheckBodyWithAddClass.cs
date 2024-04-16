using Middleware.Base;
using Helper.ReadBody;
using Control;
using Escuela.Models.Aulas;
using Helper.Respo;
using Helper.HttpStatusCodes;

namespace Middleware.CheckBodyBeforeAddClassroom;
public class Verify : MiddleBase
{
  private readonly RequestDelegate _next;

  public Verify(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext ctx)
  {
    string path = GetPath(ctx);
    int internalServerError = Codes.InternalServerError;
    int NotAcceptable = Codes.NotAcceptable;

    if (GetMethod(ctx) == HttpMethods.Post && path == "/classroom/new")
    {
      try
      {
        // TODO: Si hay valores repetidos en el body, evitar que estos se guarden en la base de datos
        R<Classrooms[]> a = await ReadBodyInMiddleware<Classrooms[]>.Read(ctx);
        var d = Ca.Ad(a.anyData);
        await _next(ctx);
        return;
      }
      catch (System.Text.Json.JsonException ex)
      {
        Exceptions(ex, ctx, NotAcceptable, "No se pudo convertir el valor a string");
        return;
      }
      catch (System.InvalidOperationException ex)
      {
        Exceptions(ex, ctx, NotAcceptable, "Operación invalida");
        return;
      }
      catch (System.Exception ex)
      {
        Exceptions(ex, ctx, internalServerError, "Error del servidor");
        return;
      }
    }
    else
    {
      await _next(ctx);
    }
  }
}

