using Lsj.Util.JSON;
using Lsj.Util.Text;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    public class TransferQueryResult : BaseJsonResult
    {
        public TransferQueryResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        public string OrderNo { get; private set; }
        public string TradeNo { get; private set; }
        public TransferState TradeState { get; private set; }

        protected override string NodeName => "alipay_fund_trans_order_query_response";

        protected override void ParseExtra()
        {
            this.OrderNo = this.response.out_biz_no;
            this.TradeNo = this.response.order_id;
            this.TradeState = (TransferState)Enum.Parse(typeof(TransferState), this.response.status);
        }
    }
}
