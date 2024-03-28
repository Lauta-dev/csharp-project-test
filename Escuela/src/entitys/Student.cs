using Escuela.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models.Alumno;

[Table("student")]
public class Student: Person {
  [Column("classroom_id")]
  public string? AulaId { get; set; }
  
  [Column("classroom")]
  public Aulas.Classrooms? Aula {get; set; }
}
