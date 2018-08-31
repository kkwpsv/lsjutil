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
            if (payMode == PayMode.Embedded)
            {
                extra.qrcode_width = qrcodeWidth.ToString();
            }


            data["biz_content"] = JSONConverter.ConvertToJSONString(extra);



            data["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data.DoSign(this.rsa);
            return data;
        }

        public AlipayPayData WapPay(string returnUrl, string notifyUrl, string orderNo, int totalFee, string subject, string body = null, bool isVirtual = false, PayMode payMode = PayMode.Jump, int qrcodeWidth = 50)
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
            extra.qr_pay_mode = ((int)payMode).ToString();
            if (!body.IsNullOrEmpty())
            {
                extra.body = body;
            }
            if (isVirtual)
            {
                extra.goods_type = 0;
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


        public OrderQueryResult OrderQuery(string alipayOrderNo, string orderNo)
        {
            var data = this.BuildBaseData();
            data["method"] = "alipay.trade.page.pay";

            dynamic extra = new ExpandoObject();
            if (!alipayOrderNo.IsNullOrEmpty())
            {
                extra.trade_no = alipayOrderNo;
            }
            else if (!orderNo.IsNullOrEmpty())
            {
                extra.out_trade_no = alipayOrderNo;
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

    }
    public enum PayMode
    {
        SimpleFront,
        Front,
        Jump,
        MiniFront,
        Embedded
    }
    public enum TradeState
    {
        NULL,
        WAIT_BUYER_PAY,
        TRADE_CLOSED,
        TRADE_SUCCESS,
        TRADE_FINISHED
    }
}
