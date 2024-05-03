using ConsoleApp.PostgreSQL;

using Escuela.Models.TeacherModel;
using Helper.Responses;

using Model.PostTeacher;
using Model.GetTeachers;
using Model.DeleteTeachers;

using SchoolManagement.Teacher;

namespace TeacherManagement;
public class TeacherServieces : ISchoolManagementTeacher
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public ResponseModel AddNewTeacher(TeacherModel[] teacher) => PostTeacher.AddTeacher(_db, teacher);
  public ResponseModel GetAllTeacher() => GetTeachers.S(_db);
  async public Task<ResponseModel> RemoveTeachers(string[] ids)
  {
    var data = await new DeleteTeacher(_db).Delete(ids);
    return data;
  }
}
