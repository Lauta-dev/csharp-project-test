using Users;

namespace LoadUser
{
  class CreateUser
  {
    // Este atributo se usara para acceder a la lista.
    public static List<User> usersList;

    private static string[] firstNames = {
      "John", "Alice", "Bob", "Carol", "David", "Emma", "Frank", "Grace", "Henry", "Isabel"
    };
    public static List<User> Loaded()
    {
      List<User> users = new List<User>();

      for(int I = 0; I < firstNames.Length; I++) users.Add(new User(I.ToString(), firstNames[I]));

      usersList = users;
      
      return users;
    }
  }
}
