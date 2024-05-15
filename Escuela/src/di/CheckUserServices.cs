using ConsoleApp.PostgreSQL;
using Helper.Responses;
using Model.CheckIfExistUser;
using SchoolManagement.CheckUser;

namespace CheckUserManagent;

public class CheckUserServices : ICheckUser
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public ResponseModel CheckUser(string mail)
  {
    return new CheckUsers(_db).Exist(mail);
  }
}
