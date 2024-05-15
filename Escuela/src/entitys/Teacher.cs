using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Escuela.Models.Base;
using Escuela.Models.Tarea;

namespace Escuela.Models.TeacherModel;

[Table("teacher")]
public class TeacherModel : Person
{
  public string ClassroomsId { get; set; }

  // Materia/Asignatura
  [Column("school_subject")]
  public string SchoolSubject { get; set; }

  // Horario del profesor
  [Column("schedule")]
  [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
  [DataType(DataType.Time)]
  public DateTime Schedule { get; set; }

  public ICollection<StudentTask> studentTask { get; set; }
}
