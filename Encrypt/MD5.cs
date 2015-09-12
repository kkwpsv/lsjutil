using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Lsj.Util;

namespace Lsj.Util.Encrypt
{
    /// <summary>
    /// MD5加密辅助类
    /// </summary>
    public static class MD5
    {
        /// <summary>
        /// 获得MD5
        /// </summary>
        public static string GetMD5String(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(str.ConvertToBytes())).Replace("-", "");

        }
    }
}
