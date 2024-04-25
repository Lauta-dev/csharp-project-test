using Helper.Responses;
using Escuela.Models.TeacherModel;

namespace SchoolManagement.Teacher;
public interface ISchoolManagementTeacher
{
  public ResponseModel AddNewTeacher(TeacherModel[] teacher);
  public ResponseModel GetAllTeacher();
  public Task<ResponseModel> RemoveTeachers(string[] ids);
}
