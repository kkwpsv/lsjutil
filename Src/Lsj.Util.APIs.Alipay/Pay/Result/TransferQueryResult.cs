using Lsj.Util.JSON;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class TransferQueryResult : BaseJsonResult
    {
        public string OrderNo { get; private set; }
        public string TradeNo { get; private set; }
        public TransferState TradeState { get; private set; }
        protected override bool CheckSign()
        {
            this.response = this.jsonObj.alipay_fund_trans_order_query_response;
            var toSign = JSONConverter.ConvertToJSONString(this.response);
            return AlipayPayAPI.PublicRsa.VerifyData(toSign.ConvertToBytes(Encoding.UTF8), "SHA256", Convert.FromBase64String(this.sign));
        }
        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_biz_no;
            this.TradeNo = this.response.order_id;
            this.TradeState = (TransferState)Enum.Parse(typeof(TransferState), this.response.status);
        }
    }
}
