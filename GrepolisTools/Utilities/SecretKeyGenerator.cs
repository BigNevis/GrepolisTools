using System;
using System.Security.Cryptography;

public static class SecretKeyGenerator
{
    public static string GenerateSecretKey()
    {
        var hmac = new HMACSHA256();
        return Convert.ToBase64String(hmac.Key);
    }
}
