using Lsj.Util.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class PaymentCodePayResult : BaseJsonResult
    {
        public PaymentCodePayResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        public string OrderNo { get; private set; }
        public string TradeNo { get; private set; }
        public int TotalFee { get; private set; }

        protected override string NodeName => "alipay_trade_pay_response";

        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_trade_no;
            this.TradeNo = this.response.trade_no;
            this.TotalFee = (int)(StringHelper.ConvertToDecimal(this.response.total_amount) * 100);
        }
    }
}
