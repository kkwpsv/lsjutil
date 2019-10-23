using Lsj.Util.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Payment Code Pay Result
    /// </summary>
    public class PaymentCodePayResult : BaseJsonResult
    {
        /// <summary>
        /// Payment Code Pay Result
        /// </summary>
        /// <param name="alipayPayAPI"></param>
        public PaymentCodePayResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
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
        /// Node Name
        /// </summary>
        protected override string NodeName => "alipay_trade_pay_response";

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = response.out_trade_no;
            TradeNo = response.trade_no;
            TotalFee = (int)(StringHelper.ConvertToDecimal(response.total_amount) * 100);
        }
    }
}
