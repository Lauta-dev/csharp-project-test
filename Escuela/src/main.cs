using Escuela.Configuration;
using Middleware.CheckAll;
using Middleware.CheckBodyBeforeAddClassroom;
using Middleware.CheckTask;
using Middleware.CheckTeacher;

namespace Main;

class Principal
{
  public static void StartApp(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    string? port = Environment.GetEnvironmentVariable("PORT");

    if (string.IsNullOrEmpty(port))
      port = "5000";

    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
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
    app.UseMiddleware<CheckAllRouts>();

    app.UseCors(MyAllowSpecificOrigins);
    app.MapControllerRoute(name: "default", pattern: "{controller=HOME}/{action=Index}/{id?}");

    app.Run();
  }
}
