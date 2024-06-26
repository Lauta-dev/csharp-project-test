using System.ComponentModel.DataAnnotations.Schema;
using Escuela.Models.Base;
using Escuela.Models.Tarea;

namespace Escuela.Models.Alumno;

[Table("student")]
public class Student : Person
{
  [Column("classroom_id")]
  public string ClassroomsId { get; set; }
  public ICollection<StudentTask> studentTasks { get; set; }
}
