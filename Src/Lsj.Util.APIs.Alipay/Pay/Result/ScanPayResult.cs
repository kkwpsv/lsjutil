namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Scan Pay Result
    /// </summary>
    public class ScanPayResult : BaseJsonResult
    {
        /// <summary>
        /// Scan Pay Result
        /// </summary>
        /// <param name="alipayPayAPI"></param>
        public ScanPayResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        /// <summary>
        /// Order No
        /// </summary>
        public string OrderNo { get; private set; }

        /// <summary>
        /// QRCode
        /// </summary>
        public string QRCode { get; private set; }

        /// <summary>
        /// NodeName
        /// </summary>
        protected override string NodeName => "alipay_trade_precreate_response";

        /// <summary>
        /// ParseExtra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = response.out_trade_no;
            QRCode = response.qr_code;
        }
    }
}
