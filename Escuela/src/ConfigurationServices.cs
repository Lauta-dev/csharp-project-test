using ConsoleApp.PostgreSQL;
using System.Text.Json.Serialization;

using StudentManagement;
using SchoolManagement.AlumnoRe;

using ClassroomManagement;
using SchoolManagement.Classroom;

using TaskManagement;
using SchoolManagement.Task;

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
      services.AddScoped<ISchoolManagementClassroom, ClassroomService>();
      services.AddScoped<ISchoolManagementTask, TaskService>();
    }

    public void AddControllers()
    {
      services.AddControllers();
    }

    public void JsonConfig()
      => services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
          options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
  }
}
