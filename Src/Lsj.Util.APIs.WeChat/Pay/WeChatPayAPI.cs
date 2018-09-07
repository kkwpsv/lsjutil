using Lsj.Util.APIs.WeChat.Pay.Result;
using Lsj.Util.Encrypt;
using Lsj.Util.Net.Web;
using Lsj.Util.Text;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.APIs.WeChat.Pay
{
    public class WeChatPayAPI : DisposableClass, IDisposable
    {
        private readonly TrueRandom trueRandom;
        private readonly string appid;
        private readonly string mch_id;
        private readonly string secretKey;
        private readonly string notifyUrl;

        public WeChatPayAPI(string appID, string mchID, string secretKey, string notifyUrl)
        {
            this.appid = appID ?? throw new ArgumentNullException("AppID Cannot Be Null");
            this.mch_id = mchID ?? throw new ArgumentNullException("MchID Cannot Be Null");
            this.secretKey = secretKey ?? throw new ArgumentNullException("SecretKey Cannot Be Null");
            this.notifyUrl = notifyUrl ?? throw new ArgumentNullException("NotifyUrl Cannot Be Null");
            this.trueRandom = new TrueRandom();
        }
        protected override void CleanUpManagedResources()
        {
            this.trueRandom.Dispose();
            base.CleanUpManagedResources();
        }

        private string GetNonceStr() => MD5.GetMD5String(this.trueRandom.NextInt().ToString());


        public UnifiedOrderResult UnifiedOrder(string goodsDescription, string orderNo, int totalFee, IPAddress ip, TradeType tradeType, string deviceInfo = null, string detail = null, string attach = null, DateTime? startTime = null, DateTime? endTime = null, string goodsTag = null, string productID = null, bool isNoCreditCard = false, string openID = null, string sceneInfo = null)
        {
            if (goodsDescription.IsNullOrEmpty())
            {
                throw new ArgumentException("goodsDescription cannot be null or empty");
            }
            if (goodsDescription.Length > 128)
            {
                throw new ArgumentException("goodsDescription too long");
            }
            if (orderNo.IsNullOrEmpty())
            {
                throw new ArgumentException("orderNo cannot be null or empty");
            }
            if (orderNo.Length > 128)
            {
                throw new ArgumentException("orderNo too long");
            }
            if (ip.AddressFamily != AddressFamily.InterNetwork)
            {
                throw new ArgumentException("ip error");
            }
            if (detail != null && detail.Length > 6000)
            {
                throw new ArgumentException("detail too long");
            }
            if (attach != null && attach.Length > 127)
            {
                throw new ArgumentException("attach too long");
            }
            if (goodsTag != null && goodsTag.Length > 32)
            {
                throw new ArgumentException("goodsTag too long");
            }
            if (tradeType == TradeType.NATIVE && productID.IsNullOrEmpty())
            {
                throw new ArgumentException("productID cannot be null or empty when trade type is native");
            }
            if (productID != null && productID.Length > 32)
            {
                throw new ArgumentException("productID too long");
            }
            if (tradeType == TradeType.JSAPI && openID.IsNullOrEmpty())
            {
                throw new ArgumentException("openID cannot be null or empty when trade type is jsapi");
            }
            if (openID != null && openID.Length > 128)
            {
                throw new ArgumentException("openID too long");
            }
            if (sceneInfo != null && sceneInfo.Length > 256)
            {
                throw new ArgumentException("sceneInfo too long");
            }
            var data = new WeChatPayData
            {
                ["appid"] = this.appid,
                ["mch_id"] = this.mch_id,
                ["device_info"] = deviceInfo ?? "WEB",
                ["nonce_str"] = this.GetNonceStr(),
                ["sign_type"] = "MD5",
                ["body"] = goodsDescription,
                ["total_fee"] = totalFee.ToString(),
                ["spbill_create_ip"] = ip.ToString(),
                ["notify_url"] = notifyUrl,
                ["trade_type"] = tradeType.ToString(),
                ["out_trade_no"] = orderNo,
            };
            if (detail != null)
            {
                data["detail"] = detail;
            }
            if (attach != null)
            {
                data["attach"] = attach;
            }
            if (startTime != null)
            {
                data["time_start"] = startTime.Value.ToString("yyyyMMddHHmmss");
            }
            if (endTime != null)
            {
                data["time_expire"] = endTime.Value.ToString("yyyyMMddHHmmss");
            }
            if (goodsTag != null)
            {
                data["goods_tag"] = goodsTag;
            }
            if (productID != null)
            {
                data["product_id"] = productID;
            }
            if (isNoCreditCard)
            {
                data["limit_pay"] = "no_credit";
            }
            if (openID != null)
            {
                data["openid"] = openID;
            }
            if (sceneInfo != null)
            {
                data["scene_info"] = sceneInfo;
            }
            data.Sign(this.secretKey);


            var url = "https://api.mch.weixin.qq.com/pay/unifiedorder";

            var webClient = new WebHttpClient();
            var xmlResult = webClient.Post(url, data.ToXMLString().ConvertToBytes(Encoding.UTF8), "text/xml");

            var result = new UnifiedOrderResult(this.secretKey);
            result.Parse(xmlResult);
            return result;
        }

        public OrderQueryResult OrderQuery(string weChatOrderNo, string orderNo)
        {

            var data = new WeChatPayData
            {
                ["appid"] = this.appid,
                ["mch_id"] = this.mch_id,
                ["nonce_str"] = this.GetNonceStr(),
                ["sign_type"] = "MD5",
            };
            if (!weChatOrderNo.IsNullOrEmpty())
            {
                data["transaction_id"] = weChatOrderNo;
            }
            else if (!orderNo.IsNullOrEmpty())
            {
                data["out_trade_no"] = orderNo;
            }
            else
            {
                throw new ArgumentNullException("WeChatOrderNo and OrderNo cannot be both null");
            }
            data.Sign(this.secretKey);

            var url = "https://api.mch.weixin.qq.com/pay/orderquery";

            var webClient = new WebHttpClient();
            var xmlResult = webClient.Post(url, data.ToXMLString().ConvertToBytes(Encoding.UTF8), "text/xml");

            var result = new OrderQueryResult(this.secretKey);
            result.Parse(xmlResult);
            return result;
        }


    }
    public enum TradeType
    {
        JSAPI,
        NATIVE,
        APP,
        MWEB
    }
    public enum TradeState
    {
        NULL,
        SUCCESS,
        REFUND,
        NOTPAY,
        CLOSED,
        REVOKED,
        USERPAYING,
        PAYERROR,
    }
}
