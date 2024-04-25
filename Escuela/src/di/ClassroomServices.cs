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

  public ResponseModel AddNewClassrooms(Classrooms[] classroom)
  {
    return new PostClassroom(_db).Classroom(classroom);
  }

  async public Task<ResponseModel> RemoveClassrooms(string id)
  {
    var data = await new DeleteClassroom(_db).Remove(id);
    return data;
  }
}
