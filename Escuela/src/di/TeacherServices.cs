using ConsoleApp.PostgreSQL;

using Escuela.Models.TeacherModel;
using Helper.Responses;

using Model.PostTeacher;
using Model.GetTeachers;

using SchoolManagement.Teacher;

namespace TeacherManagement;
public class TeacherServieces : ISchoolManagementTeacher
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public R AddNewTeacher(TeacherModel[] teacher) => PostTeacher.S(_db, teacher);
  public R GetAllTeacher() => GetTeachers.S(_db);
}