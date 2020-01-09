using Lsj.Util.Text;
using System;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// PC Pay Notify Result
    /// </summary>
    public class PCPayNotifyResult : BaseFormResult
    {
        /// <summary>
        /// Order No
        /// </summary>
        public string OrderNo { get; private set; }

        /// <summary>
        /// Total Fee
        /// </summary>
        public int TotalFee { get; private set; }

        /// <summary>
        /// Trade State
        /// </summary>
        public TradeState TradeState { get; private set; }

        /// <summary>
        /// Trade No
        /// </summary>
        public string TradeNo { get; private set; }

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = data["out_trade_no"];
            TotalFee = (int)(data["total_amount"].ConvertToDecimal() * 100);
            TradeState = (TradeState)Enum.Parse(typeof(TradeState), data["trade_status"]);
            TradeNo = data["trade_no"];
        }
    }
}
