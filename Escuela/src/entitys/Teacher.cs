using Escuela.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Escuela.Models.Profe;

[Table("teacher")]
public class Teacher : Person
{
  [Column("classroom_id")]
  public string? AulaId { get; set; }

  [Column("asignature")]
  public string? Asignatura { get; set; }

  [Column("horario")]
  [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
  [DataType(DataType.Time)]
  public DateTime Horario { get; set; }

  [Column("classroom")]
  public Aulas.Classrooms? Aula { get; set; }
}
