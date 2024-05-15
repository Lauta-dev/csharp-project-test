using System.ComponentModel.DataAnnotations.Schema;
using Escuela.Models.Tarea;
using Helper.UUID;

namespace Escuela.Models.Aulas;

[Table("classrooms")]
public class Classrooms
{
  [Column("id")]
  public string Id = UUID.GenerateUUID();

  [Column("classroom")]
  public string Aula { get; set; }

  [Column("students")]
  public ICollection<Alumno.Student> Students { get; set; }

  [Column("teachers")]
  public ICollection<TeacherModel.TeacherModel> Teachers { get; set; }

  public ICollection<StudentTask> st { get; set; }
}
