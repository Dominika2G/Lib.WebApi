using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lib.Modules.Auth.Infrastructure.Helpers
{
    public static class PasswordProtection
    {
        public static string Sha256Hash(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();

            foreach(var tmp in bytes)
            {
                builder.Append(tmp.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
