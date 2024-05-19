using Helper.BasicAuthInfo;
using Helper.Responses;

namespace SchoolManagement.CheckUser;

public interface ICheckUser
{
  public ResponseModel CheckUser(Info info);
}
