using System.Text.RegularExpressions;

namespace Helper.ValidateEmails;

public class Validate
{
  public static bool Mail(string email)
  {
    Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    return regex.IsMatch(email);
  }
}
