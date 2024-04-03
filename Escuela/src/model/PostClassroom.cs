using ConsoleApp.PostgreSQL;
using Escuela.Models.Aulas;

namespace Model.PostClassroom;
class PostClassroom
{

  private readonly SchoolCtx _db;

  public PostClassroom(SchoolCtx db)
  {
    _db = db;
  }

  public object Classroom(Classrooms[] classrooms)
  {
    foreach(Classrooms classroom in classrooms)
    {
      System.Console.WriteLine(new {
        aulaid = classroom.Aula,
        id = classroom.Id

      });
      // TODO: Verificar que el aula no exista antes de agregarla
      var newValue = new Classrooms { Aula = classroom.Aula };
      _db.classroom.Add(newValue);
      _db.SaveChanges();
    }

    return "Las clases fueron añadidas con exito";
  }
}
