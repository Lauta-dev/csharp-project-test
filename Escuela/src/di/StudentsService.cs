using ConsoleApp.PostgreSQL;
using dto.StudentDto;
using Helper.Responses;
using Model.DeleteStudents;
using Model.GetStudentById;
using Model.GetStudents;
using Model.GetStudentsByClassroom;
using Model.PostStudents;
using SchoolManagement.AlumnoRe;

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
    return new GetStudentById(_db).Students(id);
  }

  public object GetStudentByClassroom(string id, int limit = 10)
  {
    return new GetStudentsByClassroom(_db).S(id, limit);
  }

  public ResponseModel AddNewStudent(StudentDto[] alumnos)
  {
    return new PostStudents(_db).AddStudents(alumnos);
  }

  public async Task<ResponseModel> RemoveStudent(string id)
  {
    var data = await new DeleteStudent(_db).Delete(id);
    return data;
  }
}
