using ConsoleApp.PostgreSQL;

using StudentManagement;
using SchoolManagement.AlumnoRe;

using ClassroomManagement;
using SchoolManagement.Classroom;

using TaskManagement;
using SchoolManagement.Task;

using TeacherManagement;
using SchoolManagement.Teacher;
using Auth0.AspNetCore.Authentication;

namespace Escuela.Configuration
{
  public class ServiceConfigurator
  {
    private readonly IServiceCollection services;
    private readonly IConfiguration Configurations;

    public ServiceConfigurator(IServiceCollection service, IConfiguration configuration)
    {
      services = service;
      Configurations = configuration;
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

    public void Auth0Config() {
      services.AddAuth0WebAppAuthentication(o =>
      {
        o.Domain = Configurations["Auth0:Domain"];
        o.ClientId = builder.Configuration["Auth0:ClientId"];
        o.ClientSecret = builder.Configuration["Auth0:SelectId"];
      }).WithAccessToken(opt =>
        opt.Audience = builder.Configuration["Auth0:Audience"]
      );
    }
  }
}
