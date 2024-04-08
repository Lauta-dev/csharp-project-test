using SchoolManagement.AlumnoRe;
using ConsoleApp.PostgreSQL;

using Escuela.Models.Alumno;
using Escuela.Models.Aulas;

using Model.GetStudents;
using Model.GetStudentById;
using Model.GetStudentsByClassroom;

using Model.PostStudents;

using Model.GetClassrooms;
using Model.PostClassroom;

using Model.PostTask;

using Escuela.Models.Tarea;

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
  public object GetClassrooms()
  {
    return new GetClassrooms(_db).Classrooms(); 
  }

  public R AddNewClassrooms(Classrooms[] classroom)
  {
    return new PostClassroom(_db).Classroom(classroom);
  }

  public R AddNewTask(StudentTask[] studentTasks) => StudentTasks.S(_db, studentTasks);
  public R GetTasks() => Model.GetTask.GetTasks.S(_db);

  // # Teacher
  public R AddNewTeacher(Escuela.Models.TeacherModel.TeacherModel[] teacher)
    => Model.PostTeacher.PostTeacher.S(_db, teacher);

  public R GetAllTeacher() => GetTeachers.S(_db);
}
