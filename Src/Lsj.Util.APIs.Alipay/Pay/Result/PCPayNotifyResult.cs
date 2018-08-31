using Lsj.Util.Text;
using System;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class PCPayNotifyResult : BaseFormResult
    {

        public string OrderNo { get; private set; }
        public int TotalFee { get; private set; }
        public TradeState TradeState { get; private set; }
        protected override void ParseExtra()
        {
            this.OrderNo = this.data["out_trade_no"];
            this.TotalFee = (int)(this.data["total_amount"].ConvertToDecimal() * 100);
            this.TradeState = (TradeState)Enum.Parse(typeof(TradeState), this.data["trade_status"]);
        }
    }
}
