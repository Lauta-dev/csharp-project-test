using dto.StudentDto;
using Helper.Responses;

namespace SchoolManagement.AlumnoRe;

public interface IRequestAlumno
{
  public List<object> GetStudents();
  public object GetStudentById(string id);
  public object GetStudentByClassroom(string id, int limit);
  public ResponseModel AddNewStudent(StudentDto[] alumnos);
  public Task<ResponseModel> RemoveStudent(string id);
}
