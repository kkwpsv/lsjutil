using Lsj.Util.JSON;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class OrderQueryResult : BaseJsonResult
    {
        public string OrderNo { get; private set; }
        public int TotalFee { get; private set; }
        public TradeState TradeState { get; private set; }
        protected override bool CheckSign()
        {
            this.response = this.jsonObj.alipay_trade_query_response;
            var toSign = JSONConverter.ConvertToJSONString(this.response);
            return AlipayPayAPI.PublicRsa.VerifyData(toSign.ConvertToBytes(Encoding.UTF8), "SHA256", Convert.FromBase64String(this.sign));
        }
        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_trade_no;
            this.TotalFee = (int)(this.response.total_amount * 100);
            this.TradeState = (TradeState)Enum.Parse(typeof(TradeState), this.response.trade_status);
        }
    }
}
