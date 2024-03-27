using Escuela.Models.Base;
using Helper.UUID;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models.Alumno;

[Table("alumnos")]
public class Alumno: Person {
  [Column("id")]
  public string Id { get; set; } = UUID.GenerateUUID();
  
  [Column("aula_id")]
  public string AulaId { get; set; }
  
  [Column("aula")]
  public Aulas.Aulas Aula {get; set; }
}
