using Lsj.Util.Text;

namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    /// <summary>
    /// Pay Notify Result
    /// </summary>
    public class PayNotifyResult : BaseResult
    {
        /// <summary>
        /// Pay Notify Result
        /// </summary>
        /// <param name="key"></param>
        public PayNotifyResult(string key) : base(key)
        {
        }

        /// <summary>
        /// Order No
        /// </summary>
        public string OrderNo { get; private set; }

        /// <summary>
        /// Total Fee
        /// </summary>
        public int TotalFee { get; private set; }

        /// <summary>
        /// Trade No
        /// </summary>
        public string TradeNo { get; private set; }

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = _data["out_trade_no"];
            TotalFee = _data["total_fee"].ConvertToInt();
            TradeNo = _data["transaction_id"];
        }
    }
}
