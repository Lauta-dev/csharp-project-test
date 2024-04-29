using Escuela.Models.Aulas;
using Helper.Responses;

namespace SchoolManagement.Classroom;
public interface ISchoolManagementClassroom
{
  public ResponseModel GetClassrooms();
  public ResponseModel AddNewClassrooms(Classrooms[] classroom);
  public Task<ResponseModel> RemoveClassrooms(string id);
}
