using ConsoleApp.PostgreSQL;
using Helper.BasicAuthInfo;
using Helper.Responses;
using Model.CheckIfExistUser;
using SchoolManagement.CheckUser;

namespace CheckUserManagent;

public class CheckUserServices : ICheckUser
{
  private readonly SchoolCtx _db;
  private readonly IConfiguration _config;

  public CheckUserServices(SchoolCtx db, IConfiguration config)
  {
    _db = db;
    _config = config;
  }

  public ResponseModel CheckUser(Info info)
  {
    return new CheckUsers(_db, _config).Exist(info);
  }
}
