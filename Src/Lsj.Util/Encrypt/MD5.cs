using System;
using System.Security.Cryptography;
using System.Text;

namespace Lsj.Util.Encrypt
{
    /// <summary>
    /// MD5
    /// </summary>
    public static class MD5
    {
        /// <summary>
        /// Get MD5 String (Upper)
        /// </summary>
        public static string GetMD5String(string str) => GetMD5String(Encoding.UTF8.GetBytes(str));

        /// <summary>
        /// Get MD5 String (Upper)
        /// </summary>
        public static string GetMD5String(byte[] data)
        {
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(data)).Replace("-", "");
        }

        /// <summary>
        /// Get Dual MD5 String (Upper)
        /// </summary>
        public static string GetDualMD5String(string str) => GetDualMD5String(Encoding.UTF8.GetBytes(str));

        /// <summary>
        /// Get Dual MD5 String (Upper)
        /// </summary>
        public static string GetDualMD5String(byte[] data)
        {
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString((md5.ComputeHash(md5.ComputeHash(data)))).Replace("-", "");
        }
    }
}