using Escuela.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models.Alumno;

[Table("student")]
public class Student: Person {
  public string ClassroomsId { get; set; }
}
