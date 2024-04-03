using Escuela.Models.Alumno;
using ConsoleApp.PostgreSQL;
using WebApi.Responses;

namespace Model.PostStudents;
class PostStudents
{

  private readonly SchoolCtx _db;

  public PostStudents(SchoolCtx db)
  {
    _db = db;
  }

  public R S(Student[] alumnos)
  {
    var finalsta = new List<Student>();

    try
    {
      foreach (Student a in alumnos)
      {
        var aula = _db.classroom.FirstOrDefault(e => e.Id == a.ClassroomsId);

        if (aula is null) return new ResponseBuilder("No existe el aula", 404).GetResult();

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
          ClassroomsId = a.ClassroomsId
        };

        //System.Console.WriteLine(data.Name);

        finalsta.Add(data);
      }

      _db.student.AddRange(finalsta);
      _db.SaveChanges();

      return new ResponseBuilder("Alumnos añadidos", 200, finalsta).GetResult();
    }
    catch (System.Text.Json.JsonException e)
    {
      return new ResponseBuilder("Alumnos añadidos", 500, e.Message).GetResult();
    }
    catch (System.Exception e)
    {
      return new ResponseBuilder("Alumnos añadidos", 500, e.InnerException.Message).GetResult();
    }


  }
}
