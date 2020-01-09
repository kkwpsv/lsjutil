using Lsj.Util.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// PC Pay Return Result
    /// </summary>
    public class PCPayReturnResult : BaseFormResult
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
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = data["out_trade_no"];
            TotalFee = (int)(data["total_amount"].ConvertToDecimal() * 100);
        }
    }
}
