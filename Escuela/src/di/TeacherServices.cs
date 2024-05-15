using ConsoleApp.PostgreSQL;
using Escuela.Models.TeacherModel;
using Helper.Responses;
using Model.DeleteTeachers;
using Model.GetTeachers;
using Model.PostTeacher;
using SchoolManagement.Teacher;

namespace TeacherManagement;

public class TeacherServieces : ISchoolManagementTeacher
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public ResponseModel AddNewTeacher(TeacherModel[] teacher) =>
    PostTeacher.AddTeacher(_db, teacher);

  public ResponseModel GetAllTeacher() => GetTeachers.S(_db);

  public async Task<ResponseModel> RemoveTeachers(string[] ids)
  {
    var data = await new DeleteTeacher(_db).Delete(ids);
    return data;
  }
}
