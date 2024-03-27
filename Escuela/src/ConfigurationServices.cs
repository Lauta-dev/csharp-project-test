using ConsoleApp.PostgreSQL;
using A;
using Interface.Alumno;

namespace Escuela.Configuration
{
  public class ServiceConfigurator
  {
    private readonly IServiceCollection services;

    public ServiceConfigurator(IServiceCollection service)
    {
      services = service;
    }

    public void Cors(string habilitarCors)
    {
      services.AddCors(opt =>
        opt.AddPolicy(name: habilitarCors, policy =>
          policy.WithOrigins("*")
        )
      );
    }

    public void AddDb()
    {
      services.AddDbContext<BloggingContext>();
    }

    public void AddScope()
    {
      services.AddScoped<IRequestAlumno, I>();
    }
  }
}
