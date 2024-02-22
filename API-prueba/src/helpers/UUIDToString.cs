public static class UUIDHelper
{
    public static string GenerateUUID()
    {
        return Guid.NewGuid().ToString();
    }
}
