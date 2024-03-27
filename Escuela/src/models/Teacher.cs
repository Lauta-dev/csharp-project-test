using Escuela.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Escuela.Models.Profe;

[Table("teacher")]
public class Teacher : Person
{
  [Column("aula_id")]
  public string AulaId { get; set; }

  [Column("asignatura")]
  public string Asignatura { get; set; }

  [Column("horario")]
  [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
  [DataType(DataType.Time)]
  public DateTime Horario { get; set; }

  [Column("aula")]
  public Aulas.Aulas Aula { get; set; }
}
