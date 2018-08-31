using System;

namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    public class OrderQueryResult : BaseResult
    {
        public OrderQueryResult(string key) : base(key)
        {
        }
        public TradeState TradeState { get; private set; }
        protected override void ParseExtra()
        {
            this.TradeState = (TradeState)Enum.Parse(typeof(TradeState), this.data["trade_state"]);
        }
    }
}
