using Lsj.Util.Dynamic;
using Lsj.Util.JSON;
using Lsj.Util.Text;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class BaseJsonResult : BaseResult
    {
        public BaseJsonResult(AlipayPayAPI alipayPayAPI) => this.alipayPayAPI = alipayPayAPI;

        public override bool Status => base.Status && this.ResultCode == "10000";
        public string ResultCode { get; private set; } = "-1";
        public string SubErrorString { get; private set; }

        private readonly AlipayPayAPI alipayPayAPI;

        protected virtual string NodeName => "";

        protected dynamic response;
        protected dynamic jsonObj;
        protected string tosign;
        protected string sign;


        public override void Parse(string str)
        {
            try
            {
                var start = str.IndexOf(this.NodeName) + this.NodeName.Length + 2;
                var end = str.IndexOf("sign") - 2;
                this.tosign = str.Substring(start, end - start);
                this.jsonObj = JSONParser.Parse(str);
                this.sign = this.jsonObj.sign;
                if (this.CheckSign())
                {
                    this.SignStatus = true;
                    this.response = DynamicHelper.GetMember(this.jsonObj, this.NodeName);
                    this.ResultCode = this.response.code;
                    if (this.ResultCode != "10000")
                    {
                        this.ErrorString = this.response.msg;
                        this.SubErrorString = this.response.sub_msg;
                    }
                    else
                    {
                        this.ParseExtra();
                    }

                }
                else
                {
                    this.SignStatus = false;
                }
            }
            catch (Exception e)
            {
                this.ParseStatus = false;
                this.ErrorString = e.ToString();
            }

        }
        protected override bool CheckSign() => this.alipayPayAPI.PublicRsa.VerifyData(this.tosign.ConvertToBytes(Encoding.UTF8), "SHA256", Convert.FromBase64String(this.sign));
    }
}
