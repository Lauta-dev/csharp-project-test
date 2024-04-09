using SchoolManagement.Classroom;
using Model.GetClassrooms;
using Model.PostClassroom;
using Escuela.Models.Aulas;
using Helper.Responses;
using ConsoleApp.PostgreSQL;

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
}
