using Escuela.Models.Alumno;
using Helper.Responses;

namespace SchoolManagement.AlumnoRe;

public interface IRequestAlumno
{
  public List<object> GetStudents();
  public object GetStudentById(string id);
  public object GetStudentByClassroom(string id, int limit);
  public ResponseModel AddNewStudent(Student[] alumnos);
  public Task<ResponseModel> RemoveStudent(string id);
}
