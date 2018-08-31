using Lsj.Util.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class PCPayReturnResult : BaseFormResult
    {

        public string OrderNo { get; private set; }
        public int TotalFee { get; private set; }
        protected override void ParseExtra()
        {
            this.OrderNo = this.data["out_trade_no"];
            this.TotalFee = (int)(this.data["total_amount"].ConvertToDecimal() * 100);
        }
    }
}
