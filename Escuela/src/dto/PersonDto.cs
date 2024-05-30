namespace dto.PersonDto;

public class BasePersonDto
{
  public string name { get; set; }
  public string last_name { get; set; }
  public string age { get; set; }
  public string mail { get; set; }
  public string password { get; set; }
  public int rol { get; set; } = default;
  public DateTime date_of_birth { get; set; }
}
