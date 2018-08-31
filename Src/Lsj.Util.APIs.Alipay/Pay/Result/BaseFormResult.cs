using System;
using System.Collections.Generic;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class BaseFormResult : BaseResult
    {
        public void Parse(Dictionary<string, string> src)
        {
            try
            {
                this.data = new AlipayPayData(src);

                if (this.CheckSign())
                {
                    this.SignStatus = true;
                    this.ParseExtra();
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
    }
}
