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

    var MyAllowSpecificOrigins = "cors";
    configServices.Cors(MyAllowSpecificOrigins);

    var app = builder.Build();

    app.UseMiddleware<CheckClassrooms>();
    app.UseMiddleware<CheckTasks>();

    app.UseCors(MyAllowSpecificOrigins);
    app.MapControllerRoute(name: "default", pattern: "{controller=HOME}/{action=Index}/{id?}");

    app.Run();
  }
}
