namespace Helper.CompareDateTime;

class CompareIf
{
  // Este método retorna true si t1 esta adelantado de t2
  static public bool A(DateTime t1, DateTime t2)
  {
    int compare = DateTime.Compare(t1, t2);
    System.Console.WriteLine("compare {0}", compare);

    if (compare == 1 || compare == 0)
      return true;

    return false;
  }

  public static bool B(DateTime t1, DateTime t2)
  {
    int compare = DateTime.Compare(t1, t2);

    if (compare == -1)
      return true;

    return false;
  }
}
