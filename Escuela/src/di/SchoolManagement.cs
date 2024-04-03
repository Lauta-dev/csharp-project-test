using Escuela.Models.Alumno;
using Escuela.Models.Aulas;
using WebApi.Responses;

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
  
  // Get
  public object GetClassrooms();

  // Post
  public object AddNewClassrooms(Classrooms[] classroom);
}
