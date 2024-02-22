using Microsoft.AspNetCore.Mvc;
using Messages;

namespace UpdateUserInfo
{
  class User
  {
    private static object SearchUser(string id, string name)
    {
      Message message;
      var users = ReturnAllUsers.UserCollection.users;
      bool searchUser = users.Exists(x => x.id == id);

      if (!searchUser)
      {
        message = new Message("El usuario no existe", 400);
        return Results.BadRequest(message);
      }
      string oldName = "";

      var userUpdate = users.Select((x) => 
      {
        if (x.id == id)
        {
          oldName = x.name;
          x.name = name;
        }

        return x;
      }).ToList();

      users = userUpdate;
      message = new Message($"El usuario con el nombre: {oldName} fue cambiado por: {name}", 1);
      return message; 
    }
  

    public static object Update(string id, [FromBody] U name)
    {
      if (!int.TryParse(id, out _))
      {
        var comment = new IfIdNotANumber().GetMessage();
        return Results.BadRequest(comment);
      }

      return SearchUser(id, name.name);
    }
  }

  class U
  {
    public string name { get; set; }
  }
}
