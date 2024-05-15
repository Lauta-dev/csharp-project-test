using ConsoleApp.PostgreSQL;
using SchoolManagement.CheckUser;
using Model.CheckIfExistUser;
using Helper.Responses;

namespace CheckUserManagent;
public class CheckUserServices: ICheckUser
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public ResponseModel CheckUser(string mail)
  {
    return new CheckUsers(_db).Exist(mail);
  }

}
