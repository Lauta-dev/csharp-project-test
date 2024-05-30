using DbSettings;
using Escuela.Models.Admins;
using Escuela.Models.Alumno;
using Escuela.Models.Aulas;
using Escuela.Models.Tarea;
using Escuela.Models.TeacherModel;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.PostgreSQL
{
  public class SchoolCtx : DbContext
  {
    public DbSet<Student> student { get; set; }
    public DbSet<Classrooms> classroom { get; set; }
    public DbSet<TeacherModel> teacher { get; set; }
    public DbSet<StudentTask> task { get; set; }
    public DbSet<Admin> admin { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
      // Asignar PK
      mb.Entity<Classrooms>().HasKey(key => key.Id);
      mb.Entity<Student>().HasKey(key => key.Id);
      mb.Entity<TeacherModel>().HasKey(key => key.Id);
      mb.Entity<StudentTask>().HasKey(key => key.Id);
      mb.Entity<Admin>().HasKey(key => key.Id);

      // # Relaciones
      mb.Entity<Classrooms>().HasMany(e => e.st).WithOne(e => e.classroom);
      mb.Entity<TeacherModel>().HasMany(e => e.studentTask).WithOne(e => e.teacher);
      mb.Entity<Student>().HasMany(e => e.studentTasks).WithOne(e => e.student);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

      var db = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
      optionsBuilder.UseNpgsql(
        $"Host={db.Host};Database={db.DatabaseName};Username={db.Username};Password={db.Password}"
      );
    }
  }
}
