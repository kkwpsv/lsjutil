using Lsj.Util.JSON;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class TransferToAccountResult : BaseJsonResult
    {
        public string OrderNo { get; private set; }
        public string TradeNo { get; private set; }

        protected override bool CheckSign()
        {
            this.response = this.jsonObj.alipay_fund_trans_toaccount_transfer_response;
            var toSign = JSONConverter.ConvertToJSONString(this.response);
            return AlipayPayAPI.PublicRsa.VerifyData(toSign.ConvertToBytes(Encoding.UTF8), "SHA256", Convert.FromBase64String(this.sign));
        }
        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_biz_no;
            this.TradeNo = this.response.order_id;
        }
    }
}
