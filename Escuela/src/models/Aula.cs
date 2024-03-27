using Helper.UUID;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models.Aulas;
[Table("aulas")]
public class Aulas {

  [Column("id")]
  public string Id  { get; }= UUID.GenerateUUID(); 
  
  [Column("aula")]
  public string Aula { get; set; } // NOTE: Esto podria ser un enum
  
  [Column("alumnos")]
  public ICollection<Alumno.Alumno> Alumnos { get; set; }
}
