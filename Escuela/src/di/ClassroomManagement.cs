using Escuela.Models.Aulas;
using Helper.Responses;

namespace SchoolManagement.Classroom;
public interface ISchoolManagementClassroom
{
  public object GetClassrooms();
  public ResponseModel AddNewClassrooms(Classrooms[] classroom);
  public Task<ResponseModel> RemoveClassrooms(string id);
}
