using ConsoleApp.PostgreSQL;
using StudentManagement;
using SchoolManagement.AlumnoRe;

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
      services.AddDbContext<SchoolCtx>();
    }

    public void AddScope()
    {
      services.AddScoped<IRequestAlumno, AlumnoService>();
    }

    public void AddControllers() {
      services.AddControllers();
    }
  }
}
