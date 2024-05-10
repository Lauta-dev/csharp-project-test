using ConsoleApp.PostgreSQL;
using StudentManagement;
using SchoolManagement.AlumnoRe;

using ClassroomManagement;
using SchoolManagement.Classroom;

using TaskManagement;
using SchoolManagement.Task;

using TeacherManagement;
using SchoolManagement.Teacher;

using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

    public void ConfigAuth()
    {
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opt =>
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configurations["Jwt:Issuer"],
                ValidAudience = Configurations["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configurations["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
      });
    }
  }
}
