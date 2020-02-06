using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Lsj.Util.Net.Web.Session
{
    /// <summary>
    /// Session Object
    /// </summary>
    public class HttpSession
    {

#if NETCOREAPP1_1
        RandomNumberGenerator randgen;
#else
        RNGCryptoServiceProvider randgen;
#endif

        /// <summary>
        /// Session ID
        /// </summary>
        public string ID
        {
            get;
            private set;
        }

        /// <summary>
        /// Last Use Time
        /// </summary>
        public DateTime LastUseTime
        {
            get;
            private set;
        }
        Dictionary<string, object> sessions = new Dictionary<string, object>();
        private static char[] s_encoding;
        private static bool[] s_legalchars;

        public object this[string key]
        {
            get
            {
                LastUseTime = DateTime.Now;
                return sessions.ContainsKey(key) ? sessions[key] : null;
            }
            set
            {
                LastUseTime = DateTime.Now;
                if (sessions.ContainsKey(key))
                {
                    if (value == null)
                    {
                        sessions.Remove(key);
                    }
                    else
                    {
                        sessions[key] = value;
                    }
                }
                else
                {
                    this.sessions.Add(key, value);
                }
            }
        }
        public HttpSession()
        {
#if NETCOREAPP1_1
            randgen = RandomNumberGenerator.Create();
#else
            randgen = new RNGCryptoServiceProvider();
#endif
            byte[] buffer = new byte[15];
            randgen.GetBytes(buffer);
            char[] array = new char[24];
            int num = 0;
            for (int i = 0; i < 15; i += 5)
            {
                int expr_2E = (int)buffer[i] | (int)buffer[i + 1] << 8 | (int)buffer[i + 2] << 16 | (int)buffer[i + 3] << 24;
                int num2 = expr_2E & 31;
                array[num++] = s_encoding[num2];
                num2 = (expr_2E >> 5 & 31);
                array[num++] = s_encoding[num2];
                num2 = (expr_2E >> 10 & 31);
                array[num++] = s_encoding[num2];
                num2 = (expr_2E >> 15 & 31);
                array[num++] = s_encoding[num2];
                num2 = (expr_2E >> 20 & 31);
                array[num++] = s_encoding[num2];
                num2 = (expr_2E >> 25 & 31);
                array[num++] = s_encoding[num2];
                int expr_BB = (expr_2E >> 30 & 3) | (int)buffer[i + 4] << 2;
                num2 = (expr_BB & 31);
                array[num++] = s_encoding[num2];
                num2 = (expr_BB >> 5 & 31);
                array[num++] = s_encoding[num2];
            }
            this.ID = new string(array);
            this.LastUseTime = DateTime.Now;
        }
        static HttpSession()
        {
            HttpSession.s_encoding = new char[]
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
                '0',
                '1',
                '2',
                '3',
                '4',
                '5'
            };
            HttpSession.s_legalchars = new bool[128];
            for (int i = s_encoding.Length - 1; i >= 0; i--)
            {
                char c = s_encoding[i];
                s_legalchars[(int)c] = true;
            }
        }
    }
}
