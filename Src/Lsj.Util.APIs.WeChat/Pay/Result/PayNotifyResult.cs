using Lsj.Util.Text;

namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    public class PayNotifyResult : BaseResult
    {
        public PayNotifyResult(string key) : base(key)
        {
        }

        public string OrderNo { get; private set; }
        public int TotalFee { get; private set; }
        public string TradeNo { get; private set; }

        protected override void ParseExtra()
        {
            this.OrderNo = this.data["out_trade_no"];
            this.TotalFee = this.data["total_fee"].ConvertToInt();
            this.TradeNo = this.data["transaction_id"];
        }
    }
}
