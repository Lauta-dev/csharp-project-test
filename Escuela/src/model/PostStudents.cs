using Escuela.Models.Alumno;
using ConsoleApp.PostgreSQL;

namespace Model.PostStudents;
class PostStudents
{

  private readonly SchoolCtx _db;

  public PostStudents(SchoolCtx db)
  {
    _db = db;
  }

  public object S(Student[] alumnos)
  {
    foreach (Student a in alumnos)
    {
      var aula = _db.classroom.FirstOrDefault(e => e.Id == a.AulaId);

      if (aula is null) return "No existe el aula";

      // NOTE: 
      //  # Se me ocurrio ir verificando por
      //    - Edad del estudiante es >= 12 && 18 <=
      //    - Verificar que la fecha este correcta
      //    - Verificar que el apellido y nombre no lleven números

      var data = new Student
      {
        Name = a.Name,
        LastName = a.LastName,
        Age = a.Age,
        FechaDeNacimiento = a.FechaDeNacimiento,
        AulaId = a.AulaId
      };

      _db.student.Add(data);

      _db.SaveChanges();
    }

    return "Paso";
  }
}
