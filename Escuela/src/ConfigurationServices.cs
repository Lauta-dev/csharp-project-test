using ConsoleApp.PostgreSQL;

using StudentManagement;
using SchoolManagement.AlumnoRe;

using ClassroomManagement;
using SchoolManagement.Classroom;

using TaskManagement;
using SchoolManagement.Task;

using TeacherManagement;
using SchoolManagement.Teacher;

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
      services.AddScoped<MiddleBase>();
      services.AddScoped<IRequestAlumno, AlumnoService>();
      services.AddScoped<ISchoolManagementClassroom, ClassroomService>();
      services.AddScoped<ISchoolManagementTask, TaskService>();
      services.AddScoped<ISchoolManagementTeacher, TeacherServieces>();
    }

    public void AddControllers()
    {
      services.AddControllers();
    }

    public void JsonConfig()
    {
      services.AddControllersWithViews()
        .AddJsonOptions(options =>
        {
          
          options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
          options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
    }
  }
}
