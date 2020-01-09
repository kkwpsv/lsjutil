using Lsj.Util.Dynamic;
using Lsj.Util.JSON;
using Lsj.Util.Text;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Base Json Result
    /// </summary>
    public abstract class BaseJsonResult : BaseResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alipayPayAPI"></param>
        protected BaseJsonResult(AlipayPayAPI alipayPayAPI) => _alipayPayAPI = alipayPayAPI;

        private readonly AlipayPayAPI _alipayPayAPI;

        /// <summary>
        /// Status
        /// </summary>
        public override bool Status => base.Status && ResultCode == "10000";

        /// <summary>
        /// Result Code
        /// </summary>
        public string ResultCode { get; private set; } = "-1";

        /// <summary>
        /// Sub Error String
        /// </summary>
        public string SubErrorString { get; private set; }

        /// <summary>
        /// Node Name
        /// </summary>
        protected virtual string NodeName => "";

        /// <summary>
        /// Response
        /// </summary>
        protected dynamic response;

        /// <summary>
        /// Json Obj
        /// </summary>
        protected dynamic jsonObj;

        /// <summary>
        /// To Sign String
        /// </summary>
        protected string tosign;

        /// <summary>
        /// Sign
        /// </summary>
        protected string sign;

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        public override void Parse(string str)
        {
            try
            {
                var start = str.IndexOf(NodeName) + NodeName.Length + 2;
                var end = str.IndexOf("sign") - 2;
#if NETCOREAPP3_0
                tosign = str[start..end];
#else
                tosign = str.Substring(start, end - start);
#endif
                jsonObj = JSONParser.Parse(str);
                sign = jsonObj.sign;
                if (CheckSign())
                {
                    SignStatus = true;
                    response = DynamicHelper.GetMember(jsonObj, NodeName);
                    ResultCode = response.code;
                    if (ResultCode != "10000")
                    {
                        ErrorString = response.msg;
                        SubErrorString = response.sub_msg;
                    }
                    else
                    {
                        ParseExtra();
                    }

                }
                else
                {
                    SignStatus = false;
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception e)
            {
                ParseStatus = false;
                ErrorString = e.ToString();
            }
#pragma warning restore CA1031 // Do not catch general exception types

        }

        /// <summary>
        /// Check Sign
        /// </summary>
        /// <returns></returns>
        protected override bool CheckSign() => _alipayPayAPI.PublicRsa.VerifyData(tosign.ConvertToBytes(Encoding.UTF8), "SHA256", Convert.FromBase64String(sign));
    }
}
