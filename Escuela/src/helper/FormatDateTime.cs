namespace Helper.DateParsing;

class DateParse
{
  public static string FormatDate(string dateToParse, string format = "dd/MM/yyyy")
  {
    return DateTime.Parse(dateToParse).ToString(format);
  }
}
