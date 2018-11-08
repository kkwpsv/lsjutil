using Lsj.Util;
using Lsj.Util.Text;
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
        public static string GetMD5String(string str)
        {
#if NETSTANDARD
            using (var hasher = IncrementalHash.CreateHash(HashAlgorithmName.MD5))
            {
                hasher.AppendData(Encoding.UTF8.GetBytes(str));
                byte[] hash = hasher.GetHashAndReset();
                return BitConverter.ToString(hash).Replace("-", "").ToUpper();
            }
#else
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(str.ConvertToBytes())).Replace("-", "");
#endif

        }

        /// <summary>
        /// Get Dual MD5 String (Upper)
        /// </summary>
        public static string GetDualMD5String(string str)
        {
#if NETSTANDARD
            using (var hasher = IncrementalHash.CreateHash(HashAlgorithmName.MD5))
            {
                hasher.AppendData(Encoding.UTF8.GetBytes(str));
                byte[] hash = hasher.GetHashAndReset();
                using (IncrementalHash hasher2 = IncrementalHash.CreateHash(HashAlgorithmName.MD5))
                {
                    hasher2.AppendData(hash);
                    byte[] hash2 = hasher2.GetHashAndReset();
                    return BitConverter.ToString(hash2).Replace("-", "").ToUpper();
                }
            }
#else
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString((md5.ComputeHash(md5.ComputeHash(str.ConvertToBytes())))).Replace("-", "");
#endif
        }
    }
}