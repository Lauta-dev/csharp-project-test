using System.Net;
using Users;

namespace ReturnAllUsers
{
  class UserCollection
  {
    public static List<User> users = LoadUser.CreateUser.usersList;
    
    public static object GetAllUsers()
    {
      if (users.Count < 1)
      {
        var message = new { message = "No hay usuarios", statusCode = HttpStatusCode.NotFound };

        return Results.NotFound(message);
      }
    
      return Results.Json(users);

    }
  }
}
