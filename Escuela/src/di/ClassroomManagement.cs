using Escuela.Models.Aulas;
using Helper.Responses;

namespace SchoolManagement.Classroom;
public interface ISchoolManagementClassroom
{
  public object GetClassrooms();
  public R AddNewClassrooms(Classrooms[] classroom);
}
