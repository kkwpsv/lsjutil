using System;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class BaseResult
    {
        protected AlipayPayData data;
        public virtual bool Status => this.ParseStatus && this.SignStatus;
        public string ErrorString { get; protected set; }
        public bool ParseStatus { get; protected set; } = true;
        public bool SignStatus { get; protected set; } = false;

        public virtual void Parse(string str)
        {
            throw new NotImplementedException();
        }


        protected virtual bool CheckSign() => this.data.CheckSignV1();

        protected virtual void ParseExtra()
        {

        }

    }
}
