using Escuela.Configuration;
using Middleware.CheckBodyBeforeAddClassroom;
using Middleware.CheckTask;
using Middleware.CheckTeacher;

namespace Main;
class Principal
{
  public static void StartApp(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var configServices = new ServiceConfigurator(builder.Services, builder.Configuration);
    configServices.AddDb();
    configServices.AddScope();
    configServices.AddControllers();
    configServices.JsonConfig();
    configServices.ConfigAuth();

    var MyAllowSpecificOrigins = "cors";
    configServices.Cors(MyAllowSpecificOrigins);

    var app = builder.Build();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<CheckClassrooms>();
    app.UseMiddleware<CheckTasks>();
    app.UseMiddleware<CheckTeacherBody>();

    app.UseCors(MyAllowSpecificOrigins);
    app.MapControllerRoute(name: "default", pattern: "{controller=HOME}/{action=Index}/{id?}");

    app.Run();
  }
}
