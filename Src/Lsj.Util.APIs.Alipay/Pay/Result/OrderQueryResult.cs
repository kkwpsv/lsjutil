using System;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class OrderQueryResult : BaseJsonResult
    {
        public OrderQueryResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        public string OrderNo { get; private set; }
        public string TradeNo { get; private set; }
        public int TotalFee { get; private set; }
        public TradeState TradeState { get; private set; }

        protected override string NodeName => "alipay_trade_query_response";

        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_trade_no;
            this.TradeNo = this.response.trade_no;
            this.TotalFee = (int)(this.response.total_amount * 100);
            this.TradeState = (TradeState)Enum.Parse(typeof(TradeState), this.response.trade_status);
        }
    }
}
