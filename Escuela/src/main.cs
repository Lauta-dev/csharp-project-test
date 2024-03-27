using MinAPISeparateFile;
using A;
using Escuela.Configuration;

namespace Principal;
class Main
{
  public static void Tuki(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var configServices = new ServiceConfigurator(builder.Services);
    configServices.AddDb();
    configServices.AddScope();

    var habilitarCors = "ha";
    configServices.Cors(habilitarCors);

    var app = builder.Build();
    app.UseCors(habilitarCors);

    AulasControllers.MapAulas(app);
    new AlumnosControllers(new I()).MapAlumno(app);

    app.Run();
  }
}
