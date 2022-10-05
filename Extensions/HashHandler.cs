using System.Text.Json;

namespace CachingApp.Extensions;

public static class HashHandler
{
    public static string GetHashCodeHandler(object obj)
    {
        return CreateMD5(JsonSerializer.Serialize(obj));
    }

    private static string CreateMD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
