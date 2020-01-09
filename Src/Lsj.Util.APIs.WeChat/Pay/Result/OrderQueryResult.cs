using System;

namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    /// <summary>
    /// Order Query Result
    /// </summary>
    public class OrderQueryResult : BaseResult
    {
        /// <summary>
        /// Order Query Result
        /// </summary>
        /// <param name="key"></param>
        public OrderQueryResult(string key) : base(key)
        {
        }

        /// <summary>
        /// Trade State
        /// </summary>
        public TradeState TradeState { get; private set; }

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            TradeState = (TradeState)Enum.Parse(typeof(TradeState), _data["trade_state"]);
        }
    }
}
