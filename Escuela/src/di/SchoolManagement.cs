using Escuela.Models.Alumno;
using Escuela.Models.Tarea;
using Helper.Responses;

namespace SchoolManagement.AlumnoRe;

public interface IRequestAlumno
{
  // # Students
  // Gets
  public List<object> GetStudents();
  public object GetStudentById(string id);
  public object GetStudentByClassroom(string id, int limit);

  // Posts
  public R AddNewStudent(Student[] alumnos);

  // TODO: Hacer el Put
  // TODO: Hacer el Delete
  
  // # Classroom
  
  // # Task
  public R AddNewTask(StudentTask[] studentTasks);
  public R GetTasks();

  // # Teacher
  public R AddNewTeacher(Escuela.Models.TeacherModel.TeacherModel[] teacher);
  public R GetAllTeacher();
}
