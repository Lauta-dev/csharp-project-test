using SchoolManagement.AlumnoRe;
using ConsoleApp.PostgreSQL;

using Escuela.Models.Alumno;

using Model.GetStudents;
using Model.GetStudentById;
using Model.GetStudentsByClassroom;

using Model.PostStudents;


using Helper.Responses;
using Model.GetTeachers;

namespace StudentManagement;
class AlumnoService : IRequestAlumno
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public List<object> GetStudents()
  {
    return new GetStudents(_db).GetStudent();
  }

  public object GetStudentById(string id)
  {
    return new GetStudentById(_db).Student(id);
  }

  public object GetStudentByClassroom(string id, int limit = 10)
  {
    return new GetStudentsByClassroom(_db).S(id, limit);
  }

  // Post
  public R AddNewStudent(Student[] alumnos)
  {

    return new PostStudents(_db).S(alumnos);
  }

  // # Classromms



  // # Teacher
  public R AddNewTeacher(Escuela.Models.TeacherModel.TeacherModel[] teacher)
    => Model.PostTeacher.PostTeacher.S(_db, teacher);

  public R GetAllTeacher() => GetTeachers.S(_db);
}
