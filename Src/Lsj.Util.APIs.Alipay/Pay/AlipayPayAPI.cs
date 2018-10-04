using Lsj.Util.APIs.Alipay.Pay.Result;
using Lsj.Util.JSON;
using Lsj.Util.Net.Web;
using Lsj.Util.Text;
using System;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text;

namespace Lsj.Util.APIs.Alipay.Pay
{
    public class AlipayPayAPI : DisposableClass
    {
        private readonly string appid;
        private readonly RSACryptoServiceProvider rsa;


        public static RSACryptoServiceProvider PublicRsa { get; private set; }

        static AlipayPayAPI()
        {
            PublicRsa = new RSACryptoServiceProvider();
            PublicRsa.ImportParameters(new RSAParameters
            {
                Modulus = Convert.FromBase64String("g5uTaAlLnL8aeEjliqvGaNTuyXc5JK4gKgMUdY/k0DRL2dj3NOapIQTmseS1ows3ak0W3m2mHsRvMIjsWRq10hcGhluIMp3LxuWfPx4EfGYTrxVVne95nec9XmU+c2mOoQjUhqXMqVrdmsGfU9+GQMxs7j3nkBpNoBWvUAk9xKUswg/PTKC7xBlRuHGTMUkEXS42GInc3VLSILMiLQvqU4pD/Zv0Xkc6imkn5Fc3Tem6q+WigcITI53URQKDjdz7WVPBWJ5SQbA28Vw6AmooVSXyreAx1x+AYKrmscxz0DCz4CNJkIME4k1LlWepL9VLIF08EuvMnRuNLyu2vwgN2w=="),
                Exponent = Convert.FromBase64String("AQAB")
            });
        }

        public AlipayPayAPI(string appID, RSAParameters rsaKey)
        {
            this.appid = appID;
            this.rsa = new RSACryptoServiceProvider();
            this.rsa.ImportParameters(rsaKey);
        }

        protected override void CleanUpManagedResources()
        {
            this.rsa.Dispose();
            base.CleanUpManagedResources();
        }

        private AlipayPayData BuildBaseData() => new AlipayPayData
        {
            ["app_id"] = this.appid,
            ["format"] = "JSON",
            ["charset"] = "utf-8",
            ["version"] = "1.0"
        };

        /// <summary>
        /// PC支付
        /// </summary>
        /// <param name="returnUrl">返回URL</param>
        /// <param name="notifyUrl">通知URL</param>
        /// <param name="orderNo">商户单号</param>
        /// <param name="totalFee">金额</param>
        /// <param name="subject">标题</param>
        /// <param name="body">描述</param>
        /// <param name="isVirtual">是否为虚拟商品</param>
        /// <param name="payMode">支付模式</param>
        /// <param name="qrcodeWidth">二维码宽度</param>
        /// <returns></returns>
        public AlipayPayData PCPay(string returnUrl, string notifyUrl, string orderNo, int totalFee, string subject, string body = null, bool isVirtual = false, PayMode payMode = PayMode.Jump, int qrcodeWidth = 50)
        {
            if (orderNo.IsNullOrEmpty())
            {
                throw new ArgumentException("orderNo cannot be null or empty");
            }
            if (orderNo.Length > 64)
            {
                throw new ArgumentException("orderNo too long");
            }
            if (subject.IsNullOrEmpty())
            {
                throw new ArgumentException("subject cannot be null or empty");
            }
            if (subject.Length > 256)
            {
                throw new ArgumentException("subject too long");
            }

            var data = this.BuildBaseData();
            if (!returnUrl.IsNullOrEmpty())
            {
                data["return_url"] = returnUrl;
            }
            if (!notifyUrl.IsNullOrEmpty())
            {
                data["notify_url"] = notifyUrl;
            }
            data["method"] = "alipay.trade.page.pay";


            dynamic extra = new ExpandoObject();
            extra.out_trade_no = orderNo;
            extra.product_code = "FAST_INSTANT_TRADE_PAY";
            extra.total_amount = (decimal)totalFee / 100;
            extra.subject = subject;
            extra.qr_pay_mode = ((int)payMode).ToString();
            if (!body.IsNullOrEmpty())
            {
                extra.body = body;
            }
            if (isVirtual)
            {
                extra.goods_type = 0;
            }
            else
            {
                extra.goods_type = 1;
            }
            if (payMode == PayMode.Embedded)
            {
                extra.qrcode_width = qrcodeWidth.ToString();
            }


            data["biz_content"] = JSONConverter.ConvertToJSONString(extra);



            data["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data.DoSign(this.rsa);
            return data;
        }

        /// <summary>
        /// Wap支付
        /// </summary>
        /// <param name="returnUrl">返回URL</param>
        /// <param name="notifyUrl">通知URL</param>
        /// <param name="orderNo">商户单号</param>
        /// <param name="totalFee">金额</param>
        /// <param name="subject">标题</param>
        /// <param name="body">描述</param>
        /// <param name="isVirtual">是否为虚拟商品</param>
        /// <returns></returns>
        public AlipayPayData WapPay(string returnUrl, string notifyUrl, string orderNo, int totalFee, string subject, string body = null, bool isVirtual = false)
        {
            if (orderNo.IsNullOrEmpty())
            {
                throw new ArgumentException("orderNo cannot be null or empty");
            }
            if (orderNo.Length > 64)
            {
                throw new ArgumentException("orderNo too long");
            }
            if (subject.IsNullOrEmpty())
            {
                throw new ArgumentException("subject cannot be null or empty");
            }
            if (subject.Length > 256)
            {
                throw new ArgumentException("subject too long");
            }

            var data = this.BuildBaseData();
            if (!returnUrl.IsNullOrEmpty())
            {
                data["return_url"] = returnUrl;
            }
            if (!notifyUrl.IsNullOrEmpty())
            {
                data["notify_url"] = notifyUrl;
            }
            data["method"] = "alipay.trade.wap.pay";


            dynamic extra = new ExpandoObject();
            extra.out_trade_no = orderNo;
            extra.product_code = "QUICK_WAP_WAY";
            extra.total_amount = (decimal)totalFee / 100;
            extra.subject = subject;
            if (!body.IsNullOrEmpty())
            {
                extra.body = body;
            }
            if (isVirtual)
            {
                extra.goods_type = 0;
            }
            else
            {
                extra.goods_type = 1;
            }


            data["biz_content"] = JSONConverter.ConvertToJSONString(extra);



            data["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data.DoSign(this.rsa);
            return data;
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="tradeNo">支付宝单号</param>
        /// <param name="orderNo">商户单号</param>
        /// <returns></returns>
        public OrderQueryResult OrderQuery(string tradeNo, string orderNo)
        {
            var data = this.BuildBaseData();
            data["method"] = "alipay.trade.query";

            dynamic extra = new ExpandoObject();
            if (!tradeNo.IsNullOrEmpty())
            {
                extra.trade_no = tradeNo;
            }
            else if (!orderNo.IsNullOrEmpty())
            {
                extra.out_trade_no = orderNo;
            }
            else
            {
                throw new ArgumentNullException("AlipayOrderNo and OrderNo cannot be both null");
            }
            data["biz_content"] = JSONConverter.ConvertToJSONString(extra);
            data["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data.DoSign(this.rsa);

            var webClient = new WebHttpClient();
            var jsonResult = webClient.Get("https://openapi.alipay.com/gateway.do?" + data.ToQueryString()).ConvertFromBytes(Encoding.UTF8);

            var result = new OrderQueryResult();
            result.Parse(jsonResult);
            return result;
        }

        /// <summary>
        /// 转账到支付宝账户
        /// </summary>
        /// <param name="orderNo">商户转账单号</param>
        /// <param name="payeeType">收款账户类型</param>
        /// <param name="payeeAccount">收款账户</param>
        /// <param name="amount">金额</param>
        /// <param name="payerName">付款方姓名</param>
        /// <param name="payeeName">收款方真实姓名</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public TransferToAccountResult TransferToAccount(string orderNo, PayeeType payeeType, string payeeAccount, int amount, string payerName, string payeeName, string remark)
        {
            if (orderNo.IsNullOrEmpty())
            {
                throw new ArgumentException("orderNo cannot be null or empty");
            }
            if (orderNo.Length > 64)
            {
                throw new ArgumentException("orderNo too long");
            }
            if (!Enum.IsDefined(typeof(PayeeType), payeeType))
            {
                throw new ArgumentException("payeeType is invalid");
            }
            if (payeeAccount.IsNullOrEmpty())
            {
                throw new ArgumentException("payeeAccount cannot be null or empty");
            }
            if (payeeAccount.Length > 100)
            {
                throw new ArgumentException("payeeAccount too long");
            }
            if (amount < 10)
            {
                throw new ArgumentException("amount too small");
            }

            var data = this.BuildBaseData();
            data["method"] = "alipay.fund.trans.toaccount.transfer";

            dynamic extra = new ExpandoObject();
            extra.out_biz_no = orderNo;
            extra.payee_type = payeeType.ToString();
            extra.payee_account = payeeAccount;
            extra.amount = (decimal)amount / 100;
            if (!payerName.IsNullOrEmpty())
            {
                extra.payer_show_name = payerName;
            }
            if (!payeeName.IsNullOrEmpty())
            {
                extra.payee_real_name = payeeName;
            }
            if (!remark.IsNullOrEmpty())
            {
                extra.remark = remark;
            }

            data["biz_content"] = JSONConverter.ConvertToJSONString(extra);
            data["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data.DoSign(this.rsa);

            var webClient = new WebHttpClient();
            var jsonResult = webClient.Get("https://openapi.alipay.com/gateway.do?" + data.ToQueryString()).ConvertFromBytes(Encoding.UTF8);

            var result = new TransferToAccountResult();
            result.Parse(jsonResult);
            return result;
        }

        /// <summary>
        /// 转账订单查询
        /// </summary>
        /// <param name="tradeNo">支付宝转账单号</param>
        /// <param name="orderNo">商户转账单号</param>
        /// <returns></returns>
        public TransferQueryResult TransferQuery(string tradeNo, string orderNo)
        {
            var data = this.BuildBaseData();
            data["method"] = "alipay.fund.trans.order.query";

            dynamic extra = new ExpandoObject();
            if (!tradeNo.IsNullOrEmpty())
            {
                extra.order_id = tradeNo;
            }
            else if (!orderNo.IsNullOrEmpty())
            {
                extra.out_biz_no = orderNo;
            }
            else
            {
                throw new ArgumentNullException("AlipayOrderNo and OrderNo cannot be both null");
            }
            data["biz_content"] = JSONConverter.ConvertToJSONString(extra);
            data["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data.DoSign(this.rsa);

            var webClient = new WebHttpClient();
            var jsonResult = webClient.Get("https://openapi.alipay.com/gateway.do?" + data.ToQueryString()).ConvertFromBytes(Encoding.UTF8);

            var result = new TransferQueryResult();
            result.Parse(jsonResult);
            return result;
        }
    }

    /// <summary>
    /// 收款账号类型
    /// </summary>
    public enum PayeeType
    {
        /// <summary>
        /// 支付宝唯一用户号
        /// </summary>
        ALIPAY_USERID,
        /// <summary>
        /// 支付宝登录号
        /// </summary>
        ALIPAY_LOGONID
    }

    /// <summary>
    /// 支付模式
    /// </summary>
    public enum PayMode
    {
        /// <summary>
        /// 简约前置
        /// </summary>
        SimpleFront,
        /// <summary>
        /// 前置
        /// </summary>
        Front,
        /// <summary>
        /// 跳转
        /// </summary>
        Jump,
        /// <summary>
        /// 迷你前置
        /// </summary>
        MiniFront,
        /// <summary>
        /// 嵌入
        /// </summary>
        Embedded
    }

    /// <summary>
    /// 交易状态
    /// </summary>
    public enum TradeState
    {
        /// <summary>
        /// 
        /// </summary>
        NULL,
        /// <summary>
        /// 交易创建，等待买家付款
        /// </summary>
        WAIT_BUYER_PAY,
        /// <summary>
        /// 未付款交易超时关闭，或支付完成后全额退款
        /// </summary>
        TRADE_CLOSED,
        /// <summary>
        /// 交易支付成功
        /// </summary>
        TRADE_SUCCESS,
        /// <summary>
        /// 交易结束，不可退款
        /// </summary>
        TRADE_FINISHED
    }

    /// <summary>
    /// 转账状态
    /// </summary>
    public enum TransferState
    {
        /// <summary>
        /// 
        /// </summary>
        NULL,
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS,
        /// <summary>
        /// 失败
        /// </summary>
        FAIL,
        /// <summary>
        /// 等待处理
        /// </summary>
        INIT,
        /// <summary>
        /// 处理中
        /// </summary>
        DEALING,
        /// <summary>
        /// 退票
        /// </summary>
        REFUND,
        /// <summary>
        /// 未知
        /// </summary>
        UNKNOWN
    }
}
