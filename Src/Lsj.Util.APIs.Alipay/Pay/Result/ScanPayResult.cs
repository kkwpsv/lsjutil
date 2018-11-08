namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class ScanPayResult : BaseJsonResult
    {
        public ScanPayResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        public string OrderNo { get; private set; }
        public string QRCode { get; private set; }

        protected override string NodeName => "alipay_trade_precreate_response";

        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_trade_no;
            this.QRCode = this.response.qr_code;
        }
    }
}
