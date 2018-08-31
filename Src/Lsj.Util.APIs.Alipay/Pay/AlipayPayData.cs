using Lsj.Util.Collections;
using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay
{
    public class AlipayPayData : SafeDictionary<string, string>
    {
        public AlipayPayData() : base()
        {
        }
        public AlipayPayData(Dictionary<string, string> src) : base(src)
        {
        }

        public void DoSign(RSACryptoServiceProvider rsa)
        {
            this["sign_type"] = "RSA2";
            var tosign = new StringBuilder();
            foreach (var item in this.OrderBy(x => x.Key))
            {
                tosign.Append($"{item.Key}={item.Value}&");
            }
            tosign.RemoveLastOne();
            this["sign"] = Convert.ToBase64String(rsa.SignData(tosign.ToString().ConvertToBytes(Encoding.UTF8), "SHA256"));
        }
        public bool CheckSignV1()
        {
            var signType = this["sign_type"];
            if (signType != "RSA2")
            {
                throw new NotImplementedException("unsupport sign type");
            }
            var tosign = new StringBuilder();
            foreach (var item in this.Where(x => x.Key != "sign_type" && x.Key != "sign").OrderBy(x => x.Key))
            {
                tosign.Append($"{item.Key}={item.Value}&");
            }
            tosign.RemoveLastOne();

            return AlipayPayAPI.PublicRsa.VerifyData(tosign.ToString().ConvertToBytes(Encoding.UTF8), "SHA256", Convert.FromBase64String(this["sign"]));
        }

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
