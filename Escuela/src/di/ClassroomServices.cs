using SchoolManagement.Classroom;
using Model.GetClassrooms;
using Model.PostClassroom;
using Escuela.Models.Aulas;
using Helper.Responses;
using ConsoleApp.PostgreSQL;

using Model.DeleteClassrooms;

namespace ClassroomManagement;

class ClassroomService : ISchoolManagementClassroom
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public object GetClassrooms()
  {
    return new GetClassrooms(_db).Classrooms(); 
  }

  public R AddNewClassrooms(Classrooms[] classroom)
  {
    return new PostClassroom(_db).Classroom(classroom);
  }

  public R RemoveClassrooms(string id)
  {
    return new DeleteClassroom(_db).Remove(id);
  }
}
