using ConsoleApp.PostgreSQL;
using Escuela.Models.Aulas;
using Helper.Responses;
using Model.DeleteClassrooms;
using Model.GetClassrooms;
using Model.PostClassroom;
using SchoolManagement.Classroom;

namespace ClassroomManagement;

class ClassroomService : ISchoolManagementClassroom
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public ResponseModel GetClassrooms()
  {
    return new GetClassrooms(_db).Classrooms();
  }

  public ResponseModel AddNewClassrooms(Classrooms[] classroom)
  {
    return new PostClassroom(_db).Classroom(classroom);
  }

  public async Task<ResponseModel> RemoveClassrooms(string id)
  {
    var data = await new DeleteClassroom(_db).Remove(id);
    return data;
  }
}
