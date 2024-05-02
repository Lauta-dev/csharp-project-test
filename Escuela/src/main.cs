using Escuela.Configuration;
using Middleware.CheckBodyBeforeAddClassroom;
using Middleware.CheckTask;
using Middleware.CheckTeacher;
using Auth0.AspNetCore.Authentication;

namespace Main;
class Principal
{
  public static void StartApp(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var configServices = new ServiceConfigurator(builder.Services);
    configServices.AddDb();
    configServices.AddScope();
    configServices.AddControllers();
    configServices.JsonConfig();

    builder.Services.AddAuth0WebAppAuthentication(o =>
    {
      o.Domain = builder.Configuration["Auth0:Domain"];
      o.ClientId = builder.Configuration["Auth0:ClientId"];
      o.ClientSecret = builder.Configuration["Auth0:SelectId"];
    }).WithAccessToken(opt =>
      opt.Audience = builder.Configuration["Auth0:Audience"]
    );

    var MyAllowSpecificOrigins = "cors";
    configServices.Cors(MyAllowSpecificOrigins);

    var app = builder.Build();

    app.MapGet("/", () =>
    {
      return "asdasd";    
    });

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
