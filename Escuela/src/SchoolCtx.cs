using Microsoft.EntityFrameworkCore;
using DbSettings;
using Escuela.Models.Alumno;
using Escuela.Models.Aulas;
using Escuela.Models.TeacherModel;
using Escuela.Models.Tarea;

namespace ConsoleApp.PostgreSQL
{
  public class SchoolCtx : DbContext
  {
    public DbSet<Student> student { get; set; }
    public DbSet<Classrooms> classroom { get; set; }
    public DbSet<TeacherModel> teacher { get; set; }
    public DbSet<StudentTask> task { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
      // Asignar PK
      mb.Entity<Classrooms>().HasKey(key => key.Id);  // Tabla classrooms
      mb.Entity<Student>().HasKey(key => key.Id); // Tabla student
      mb.Entity<TeacherModel>().HasKey(key => key.Id); // Tabla teacher
      mb.Entity<StudentTask>().HasKey(key => key.Id); // student_task

      // # Relaciones
      // - Tareas (tasks)
      mb.Entity<Classrooms>()
        .HasMany(e => e.st)
        .WithOne(e => e.classroom);

      // - Profesores a tareas
      mb.Entity<TeacherModel>()
        .HasMany(e => e.studentTask)
        .WithOne(e => e.teacher);
      
      // - Tareas a alumnos
      mb.Entity<Student>()
        .HasMany(e => e.studentTasks)
        .WithOne(e => e.student);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

      var db = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
      optionsBuilder.UseNpgsql($"Host={db.Host};Database={db.DatabaseName};Username={db.Username}");
    }
  }
}
