using Microsoft.AspNetCore.Mvc;
using Users;

namespace AddUser
{
  class AddUserInDB
  {
    public static string add([FromBody] User body)
    {
      var users = ReturnAllUsers.UserCollection.users;
      var name = body.name;

      var newId = UUIDHelper.GenerateUUID();
      var user = new User(newId, name);
      users.Add(user);
      return $"el usuario {name} fue añadido con exito";        
    }
  }
}

