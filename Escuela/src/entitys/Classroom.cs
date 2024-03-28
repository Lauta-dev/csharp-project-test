using Helper.UUID;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models.Aulas;
[Table("classrooms")]
public class Classrooms {

  [Column("id")]
  public string Id { get; } = UUID.GenerateUUID(); 
  
  [Column("classroom")]
  public string? Aula { get; set; }
  
  [Column("students")]
  public ICollection<Alumno.Student>? Students { get; set; }
}
