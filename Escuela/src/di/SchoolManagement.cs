using Escuela.Models.Alumno;

namespace SchoolManagement.AlumnoRe;

public interface IRequestAlumno
{
  // # Students
  // Gets
  public List<object> GetStudents();
  public object GetStudentById(string id);
  public object GetStudentByClassroom(string id, int limit);

  // Posts
  public object AddNewStudent(Student[] alumnos);

  // TODO: Hacer el Put
  // TODO: Hacer el Delete
  

  // # Classroom
  public object GetClassrooms();
}
