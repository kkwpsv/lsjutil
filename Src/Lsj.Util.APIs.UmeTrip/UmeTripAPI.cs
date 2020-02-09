using Lsj.Util.JSON;
using Lsj.Util.Net.Web;
using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Lsj.Util.APIs.UmeTrip
{
    /// <summary>
    /// UmeTrip API (decompile form android app)
    /// </summary>
    public class UmeTripAPI
    {
        /// <summary>
        /// Get Flights
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<FlightInfo> GetFlights(string from, string to, DateTime date)
        {
            var flights = new List<FlightInfo>();
            var pageSize = 1;
            var currentPage = 1;
            while (currentPage <= pageSize)
            {
                var data = new
                {
                    rchannel = "10000028",
                    rcuuid = "41543b9ef374b44b4aaf7a0b16e5e7039",
                    rcver = "AND_a01_04.67.0112",
                    rkey = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 8000",
                    rparams = new
                    {
                        order = "time_up",
                        rbeg3code = from,
                        rbegdate = date.ToString("yyyyMMdd"),
                        rbegtime = "0000",
                        rend3code = to,
                        rendtime = "2400",
                        risreturn = 0,
                        page = currentPage
                    },
                    rpid = "300053",
                    rpver = "1.0",
                };
                var postdata = JSONConverter.ConvertToJSONString(data).ConvertToBytes();
                var resultstring = new WebHttpClient().Post(@"http://ume1.umetrip.com/MSky_Front/api/msky/p3/query?encrypt=1", Convert.ToBase64String(AesEncrypt(postdata, getSecretKey(GetKey(), 16))).ConvertToBytes(), "application/octet-stream").ConvertFromBytes(Encoding.UTF8);
                var result = JSONParser.Parse(resultstring);
                pageSize = (int)result.presp.pdata.pageSize;

                flights.AddRange((result.presp.pdata.parray as JSONArray).SpecifiedTo<List<FlightInfo>>());
                currentPage++;
            }

            return flights;
        }
        private static byte[] a = Convert.FromBase64String("ql8XzFroC2vTZJaAzZq9Kw==");
        private static byte[] AesDecrypt(byte[] data, byte[] key)
        {
            var x = new RijndaelManaged();
            x.Key = key;
            x.Mode = CipherMode.ECB;
            x.Padding = PaddingMode.PKCS7;

            var decryptor = x.CreateDecryptor();
            return decryptor.TransformFinalBlock(data, 0, data.Length);
        }
        private static byte[] AesEncrypt(byte[] data, byte[] key)
        {
            var x = new RijndaelManaged();
            x.Key = key;
            x.Mode = CipherMode.ECB;
            x.Padding = PaddingMode.PKCS7;

            var encryptor = x.CreateEncryptor();
            return encryptor.TransformFinalBlock(data, 0, data.Length);
        }
        private static string GetKey()
        {
            var x = getSecretKey("umetrip_123qwe", 16);
            return AesDecrypt(a, x).ConvertFromBytes(Encoding.UTF8);
        }
        private static byte[] getSecretKey(String paramString, int paramInt)
        {
            byte[] arrayOfByte1 = paramString.ConvertToBytes(Encoding.UTF8);
            byte[] arrayOfByte2 = new byte[16];
            int j = paramString.Length;
            if (j > paramInt)
            {
                return null;
            }
            int i = 0;
            while (i < j)
            {
                arrayOfByte2[i] = arrayOfByte1[i];
                i += 1;
            }
            i = 0;
            while (i < paramInt - j)
            {
                arrayOfByte2[(j + i)] = 0;
                i += 1;
            }
            return arrayOfByte2;
        }
    }
}
