using Escuela.Configuration;
using Middleware.CheckBodyBeforeAddClassroom;
using Middleware.CheckTask;

namespace Principal;
class Main
{
  public static void Tuki(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var configServices = new ServiceConfigurator(builder.Services);
    configServices.AddDb();
    configServices.AddScope();
    configServices.AddControllers();
    configServices.JsonConfig();

    var habilitarCors = "ha";
    configServices.Cors(habilitarCors);

    var app = builder.Build();

    // TODO: Añadir los demás middleware para las demás rutas que necesiten ferificación
    app.UseMiddleware<Verify>();
    app.UseMiddleware<Check>();

    app.UseCors(habilitarCors);
    app.MapControllerRoute(name: "default", pattern: "{controller=HOME}/{action=Index}/{id?}");

    app.Run();
  }
}
