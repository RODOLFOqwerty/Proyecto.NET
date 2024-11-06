using System;
using System.Text;
using System.Security.Cryptography;

namespace SGI;

public static class SistemaHashing
{
    public static string getHash(string? input){
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input ?? "000"));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
