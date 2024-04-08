using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Escuela.Models.Aulas;
using Escuela.Models.Alumno;
using Helper.UUID;

namespace Escuela.Models.Tarea;
public class StudentTask
{
  [Column("id")]
  public string Id = UUID.GenerateUUID();

  [Column("title")]
  public string Title { get; set; }

  [Column("content")]
  public string Content { get; set; }

  [Column("important")]
  public int Important { get; set; }

  [Column("create_at")]
  [DataType(DataType.Date)]
  [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime CreateAt { get; set; }

  [Column("limit_at")]
  [DataType(DataType.Date)]
  [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime LimitAt { get; set; }

  //**************   RELACIONES  **************\\

  [ForeignKey("student")]
  [Column("student_id")]
  public string studentId { get; set; }
  public Student student { get; set; }

  [ForeignKey("teacher")]
  [Column("teacher_id")]
  public string teacherId { get; set; }
  public TeacherModel.TeacherModel teacher { get; set; }

  [ForeignKey("classroom")]
  [Column("classroom_id")]
  public string ClassroomsId { get; set; }
  public Classrooms classroom { get; set; }
}
