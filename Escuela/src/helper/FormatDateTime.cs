namespace Helper.DateParsing;
class DateParse {
  static public string FormatDate(string dateToParse, string format = "dd/MM/yyyy") {
    return DateTime.Parse(dateToParse).ToString(format);
  }
}
