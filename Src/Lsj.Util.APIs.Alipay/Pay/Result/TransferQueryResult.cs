using Lsj.Util.JSON;
using Lsj.Util.Text;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Transfer Query Result
    /// </summary>
    public class TransferQueryResult : BaseJsonResult
    {
        /// <summary>
        /// Transfer Query Result
        /// </summary>
        /// <param name="alipayPayAPI"></param>
        public TransferQueryResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
        {
        }

        /// <summary>
        /// Order No
        /// </summary>
        public string OrderNo { get; private set; }

        /// <summary>
        /// Trade No
        /// </summary>
        public string TradeNo { get; private set; }

        /// <summary>
        /// Trade State
        /// </summary>
        public TransferState TradeState { get; private set; }

        /// <summary>
        /// Node Name
        /// </summary>
        protected override string NodeName => "alipay_fund_trans_order_query_response";

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = response.out_biz_no;
            TradeNo = response.order_id;
            TradeState = (TransferState)Enum.Parse(typeof(TransferState), response.status);
        }
    }
}
