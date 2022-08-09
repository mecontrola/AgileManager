using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MeControla.Kernel.Extensions
{
    public static class StringExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string Base64Encode(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string Base64Decode(this string value)
        {
            var bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string TrimAll(this string value)
            => Regex.Replace(value, @"\s+", " ").Trim();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToMD5(this string input)
        {
            using var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();

            for (int i = 0, l = data.Length; i < l; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
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

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static decimal? ToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var str = value.Replace(",", ".");
            str = Regex.Replace(str, @"[^\d|.]", string.Empty);

            try
            {
                return decimal.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
        }
    }
}