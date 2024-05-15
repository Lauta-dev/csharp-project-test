using ConsoleApp.PostgreSQL;
using Escuela.Models.TeacherModel;
using Helper.Responses;

namespace Model.PostTeacher;

public class PostTeacher
{
  public static ResponseModel AddTeacher(SchoolCtx db, TeacherModel[] teachers)
  {
    foreach (var teacher in teachers)
    {
      var existeClassroom = db.classroom.FirstOrDefault(x => x.Id == teacher.ClassroomsId);

      if (existeClassroom is null)
        return new ResponseBuilder("El aula no existe", 400).GetResult();
    }

    db.teacher.AddRange(teachers);
    db.SaveChanges();
    return new ResponseBuilder("Add new task", 200, teachers).GetResult();
  }
}
