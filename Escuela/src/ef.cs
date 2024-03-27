using Microsoft.EntityFrameworkCore;
using DbSettings;
using Escuela.Models.Alumno;
using Escuela.Models.Aulas;

namespace ConsoleApp.PostgreSQL
{
  public class BloggingContext : DbContext
  {
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Aulas> Aulas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
      // Asignar PK (Primaty Key)
      modelBuilder.Entity<Aulas>()
        .HasKey(a => a.Id);
      
      modelBuilder.Entity<Alumno>()
        .HasKey(a => a.Id);

      // Relaciones
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

      var db = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
      var host = db.Host;
      var username = db.Username;
      var dbName = db.DatabaseName;

      optionsBuilder.UseNpgsql($"Host={host};Database={dbName};Username={username}");

    }
  }
}
