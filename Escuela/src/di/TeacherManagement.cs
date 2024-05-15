using Escuela.Models.TeacherModel;
using Helper.Responses;

namespace SchoolManagement.Teacher;

public interface ISchoolManagementTeacher
{
  public ResponseModel AddNewTeacher(TeacherModel[] teacher);
  public ResponseModel GetAllTeacher();
  public Task<ResponseModel> RemoveTeachers(string[] ids);
}
