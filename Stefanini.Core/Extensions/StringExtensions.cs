using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Stefanini.Core.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static string Base64Encode(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        [DebuggerStepThrough]
        public static string Base64Decode(this string value)
        {
            var bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }

        [DebuggerStepThrough]
        public static string TrimAll(this string value)
            => Regex.Replace(value, @"\s+", " ").Trim();

        [DebuggerStepThrough]
        public static string ToMD5(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();

            for (int i = 0, l = data.Length; i < l; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        [DebuggerStepThrough]
        public static DateTime? ToDateTime(this string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}