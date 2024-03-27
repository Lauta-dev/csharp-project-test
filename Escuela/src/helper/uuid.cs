namespace Helper.UUID;
public class UUID {
  public static string GenerateUUID() => Guid.NewGuid().ToString();
}
