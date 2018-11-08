using Lsj.Util.JSON;
using Lsj.Util.Text;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class TransferToAccountResult : BaseJsonResult
    {
        public TransferToAccountResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        public string OrderNo { get; private set; }
        public string TradeNo { get; private set; }

        protected override string NodeName => "alipay_fund_trans_toaccount_transfer_response";

        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_biz_no;
            this.TradeNo = this.response.order_id;
        }
    }
}
