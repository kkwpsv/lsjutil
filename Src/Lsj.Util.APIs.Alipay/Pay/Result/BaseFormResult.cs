using System;
using System.Collections.Generic;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Base Form Result
    /// </summary>
    public abstract class BaseFormResult : BaseResult
    {
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="src"></param>
        public void Parse(Dictionary<string, string> src)
        {
            try
            {
                data = new AlipayPayData(src);

                if (CheckSign())
                {
                    SignStatus = true;
                    ParseExtra();
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
    }
}
