using Lsj.Util.JSON;
using System;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class BaseJsonResult : BaseResult
    {
        public override bool Status => base.Status && this.ResultCode == "10000";
        public string ResultCode { get; private set; } = "-1";
        public string SubErrorString { get; private set; }

        protected dynamic response;
        protected dynamic jsonObj;
        protected string sign;

        public override void Parse(string str)
        {
            try
            {
                this.jsonObj = JSONParser.Parse(str);
                this.sign = this.jsonObj.sign;
                if (this.CheckSign())
                {
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
        protected override bool CheckSign() => throw new NotImplementedException();
    }
}
