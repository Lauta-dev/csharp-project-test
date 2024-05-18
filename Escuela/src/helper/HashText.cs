using System.Security.Cryptography;
using System.Text;

namespace Helper.HashText;

public class Hashing
{
  public static Byte[] Hash(string stringToHashing)
  {
    using SHA256 sha256 = SHA256.Create();
    byte[] stringToArrayByte = ASCIIEncoding.ASCII.GetBytes(stringToHashing);
    return sha256.ComputeHash(stringToArrayByte);
  }

  public static bool Compare(string c1, byte[] c2)
  {
    byte[] hash = Hash(c1);

    if (hash.Length != c2.Length)
    {
      return false;
    }

    for (int i = 0; i < hash.Length; i++)
    {
      if (hash[i] != c2[i])
        return false;
    }

    return true;
  }
}
