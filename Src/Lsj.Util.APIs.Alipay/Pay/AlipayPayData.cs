using Lsj.Util.Collections;
using Lsj.Util.Net.Web;
using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay
{
    /// <summary>
    /// Alipay Pay Data
    /// </summary>
    public class AlipayPayData : SafeDictionary<string, string>
    {
        private readonly AlipayPayAPI _alipayPayAPI;

        /// <summary>
        /// Alipay Pay Data
        /// </summary>
        /// <param name="alipayPayAPI"></param>
        public AlipayPayData(AlipayPayAPI alipayPayAPI) : base() => _alipayPayAPI = alipayPayAPI;

        /// <summary>
        /// Alipay Pay Data
        /// </summary>
        /// <param name="src"></param>
        public AlipayPayData(Dictionary<string, string> src) : base(src)
        {
        }

        /// <summary>
        /// Sign
        /// </summary>
        /// <param name="rsa"></param>
        public void DoSign(RSACryptoServiceProvider rsa)
        {
            this["sign_type"] = "RSA2";
            var tosign = new StringBuilder();
            foreach (var item in this.Where(x => !x.Value.IsNullOrEmpty()).OrderBy(x => x.Key))
            {
                tosign.Append($"{item.Key}={item.Value}&");
            }
            tosign.RemoveLastOne();
            this["sign"] = Convert.ToBase64String(rsa.SignData(tosign.ToString().ConvertToBytes(Encoding.UTF8), "SHA256"));
        }

        /// <summary>
        /// Check Sign V1
        /// </summary>
        /// <returns></returns>
        public bool CheckSignV1()
        {
            var signType = this["sign_type"];
            if (signType != "RSA2")
            {
                throw new NotImplementedException("unsupport sign type");
            }
            var tosign = new StringBuilder();
            foreach (var item in this.Where(x => x.Key != "sign_type" && x.Key != "sign" && !x.Value.IsNullOrEmpty()).OrderBy(x => x.Key))
            {
                tosign.Append($"{item.Key}={item.Value}&");
            }
            tosign.RemoveLastOne();

            return _alipayPayAPI.PublicRsa.VerifyData(tosign.ToString().ConvertToBytes(Encoding.UTF8), "SHA256", Convert.FromBase64String(this["sign"]));
        }

        /// <summary>
        /// To Query String
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            var result = new StringBuilder();
            foreach (var item in this.OrderBy(x => x.Key))
            {
                result.Append($"{item.Key}={item.Value}&");
            }
            result.RemoveLastOne();
            return result.ToString();
        }

        /// <summary>
        /// To Query String with Url Encode
        /// </summary>
        /// <returns></returns>
        public string ToQueryStringWithUrlEncode()
        {
            var result = new StringBuilder();
            foreach (var item in this.OrderBy(x => x.Key))
            {
                result.Append($"{item.Key}={item.Value.UrlEncode()}&");
            }
            result.RemoveLastOne();
            return result.ToString();
        }
    }
}
