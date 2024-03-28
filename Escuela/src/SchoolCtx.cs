using Microsoft.EntityFrameworkCore;
using DbSettings;
using Escuela.Models.Alumno;
using Escuela.Models.Aulas;

namespace ConsoleApp.PostgreSQL
{
  public class SchoolCtx : DbContext
  {
    public DbSet<Student> student { get; set; }
    public DbSet<Classrooms> classroom { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
      // Asignar PK (Primaty Key)
      modelBuilder.Entity<Classrooms>()
        .HasKey(a => a.Id);
      
      modelBuilder.Entity<Student>()
        .HasKey(a => a.Id);
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
