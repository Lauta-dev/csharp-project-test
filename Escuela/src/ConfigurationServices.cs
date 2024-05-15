using System.Text;
using CheckUserManagent;
using ClassroomManagement;
using ConsoleApp.PostgreSQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.AlumnoRe;
using SchoolManagement.CheckUser;
using SchoolManagement.Classroom;
using SchoolManagement.Task;
using SchoolManagement.Teacher;
using StudentManagement;
using TaskManagement;
using TeacherManagement;

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
        opt.AddPolicy(name: habilitarCors, policy => policy.WithOrigins("*"))
      );
    }

    public void AddDb()
    {
      services.AddDbContext<SchoolCtx>();
    }

    public void AddScope()
    {
      services.AddScoped<ICheckUser, CheckUserServices>();
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
      services
        .AddControllersWithViews()
        .AddJsonOptions(options =>
        {
          options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
          options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
    }

    public void ConfigAuth()
    {
      services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opt =>
          opt.TokenValidationParameters = new TokenValidationParameters
          {
            ValidIssuer = Configurations["Jwt:Issuer"],
            ValidAudience = Configurations["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(Configurations["Jwt:Key"])
            ),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
          }
        );
    }
  }
}
