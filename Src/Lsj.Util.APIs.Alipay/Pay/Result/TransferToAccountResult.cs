using Lsj.Util.JSON;
using Lsj.Util.Text;
using System;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Transfer To Account Result
    /// </summary>
    public class TransferToAccountResult : BaseJsonResult
    {
        /// <summary>
        /// Transfer To Account Result
        /// </summary>
        /// <param name="alipayPayAPI"></param>
        public TransferToAccountResult(AlipayPayAPI alipayPayAPI) : base(alipayPayAPI)
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
        /// Node Name
        /// </summary>
        protected override string NodeName => "alipay_fund_trans_toaccount_transfer_response";

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            OrderNo = response.out_biz_no;
            TradeNo = response.order_id;
        }
    }
}
