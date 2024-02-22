namespace Users
{
  class User
  {
    public string id { get; set; } = "";
    public string name { get; set; } = "";

    public User(string id , string name)
    {
      // TODO: NO tocar esto
      // Esto se utiliza en el proceso de desearilación para transformar un JSON
      // que llega desde el cliente.
      this.id = id;
      this.name = name;
    }

  }
}
