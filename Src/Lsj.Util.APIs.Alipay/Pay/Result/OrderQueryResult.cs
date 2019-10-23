using System;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Order Query Result
    /// </summary>
    public class OrderQueryResult : BaseJsonResult
    {
        /// <summary>
        /// Order Query Result
        /// </summary>
        /// <param name="alipayPayAPI"></param>
        public OrderQueryResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        /// <summary>
        /// Order No
        /// </summary>
        public string OrderNo { get; private set; }

        /// <summary>
        /// Trade No
        /// </summary>
        public string TradeNo { get; private set; }

        /// <summary>
        /// Total Fee
        /// </summary>
        public int TotalFee { get; private set; }

        /// <summary>
        /// Trade State
        /// </summary>
        public TradeState TradeState { get; private set; }

        /// <summary>
        /// Node Name
        /// </summary>
        protected override string NodeName => "alipay_trade_query_response";

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = response.out_trade_no;
            TradeNo = response.trade_no;
            TotalFee = (int)(response.total_amount * 100);
            TradeState = (TradeState)Enum.Parse(typeof(TradeState), response.trade_status);
        }
    }
}
