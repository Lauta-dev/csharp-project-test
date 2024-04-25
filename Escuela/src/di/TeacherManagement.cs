using Helper.Responses;
using Escuela.Models.TeacherModel;

namespace SchoolManagement.Teacher;
public interface ISchoolManagementTeacher
{
  public R AddNewTeacher(TeacherModel[] teacher);
  public R GetAllTeacher();
  public Task<R> RemoveTeachers(string[] ids);
}
