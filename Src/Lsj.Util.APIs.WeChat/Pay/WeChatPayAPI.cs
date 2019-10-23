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
    /// <summary>
    /// WeChat Pay API
    /// </summary>
    public class WeChatPayAPI : DisposableClass
    {
        private readonly TrueRandom _trueRandom;
        private readonly string _appid;
        private readonly string _mch_id;
        private readonly string _secretKey;
        private readonly string _notifyUrl;

        /// <summary>
        /// WeChat Pay API
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="mchID"></param>
        /// <param name="secretKey"></param>
        /// <param name="notifyUrl"></param>
        public WeChatPayAPI(string appID, string mchID, string secretKey, string notifyUrl)
        {
            _appid = appID ?? throw new ArgumentNullException("AppID Cannot Be Null");
            _mch_id = mchID ?? throw new ArgumentNullException("MchID Cannot Be Null");
            _secretKey = secretKey ?? throw new ArgumentNullException("SecretKey Cannot Be Null");
            _notifyUrl = notifyUrl ?? throw new ArgumentNullException("NotifyUrl Cannot Be Null");
            _trueRandom = new TrueRandom();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            _trueRandom.Dispose();
            base.CleanUpManagedResources();
        }

        private string GetNonceStr() => MD5.GetMD5String(_trueRandom.NextInt().ToString());

        /// <summary>
        /// Unified Order
        /// </summary>
        /// <param name="goodsDescription"></param>
        /// <param name="orderNo"></param>
        /// <param name="totalFee"></param>
        /// <param name="ip"></param>
        /// <param name="tradeType"></param>
        /// <param name="deviceInfo"></param>
        /// <param name="detail"></param>
        /// <param name="attach"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="goodsTag"></param>
        /// <param name="productID"></param>
        /// <param name="isNoCreditCard"></param>
        /// <param name="openID"></param>
        /// <param name="sceneInfo"></param>
        /// <returns></returns>
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
                ["appid"] = _appid,
                ["mch_id"] = _mch_id,
                ["device_info"] = deviceInfo ?? "WEB",
                ["nonce_str"] = GetNonceStr(),
                ["sign_type"] = "MD5",
                ["body"] = goodsDescription,
                ["total_fee"] = totalFee.ToString(),
                ["spbill_create_ip"] = ip.ToString(),
                ["notify_url"] = _notifyUrl,
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
            data.Sign(_secretKey);


            var url = "https://api.mch.weixin.qq.com/pay/unifiedorder";

            var webClient = new WebHttpClient();
            var xmlResult = webClient.Post(url, data.ToXMLString().ConvertToBytes(Encoding.UTF8), "text/xml");

            var result = new UnifiedOrderResult(_secretKey);
            result.Parse(xmlResult);
            return result;
        }

        /// <summary>
        /// Order Query
        /// </summary>
        /// <param name="weChatOrderNo"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public OrderQueryResult OrderQuery(string weChatOrderNo, string orderNo)
        {

            var data = new WeChatPayData
            {
                ["appid"] = _appid,
                ["mch_id"] = _mch_id,
                ["nonce_str"] = GetNonceStr(),
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
            data.Sign(_secretKey);

            var url = "https://api.mch.weixin.qq.com/pay/orderquery";

            var webClient = new WebHttpClient();
            var xmlResult = webClient.Post(url, data.ToXMLString().ConvertToBytes(Encoding.UTF8), "text/xml");

            var result = new OrderQueryResult(_secretKey);
            result.Parse(xmlResult);
            return result;
        }
    }

    /// <summary>
    /// Trade Type
    /// </summary>
    public enum TradeType
    {
        /// <summary>
        /// JSAPI
        /// </summary>
        JSAPI,

        /// <summary>
        /// Native
        /// </summary>
        NATIVE,

        /// <summary>
        /// App
        /// </summary>
        APP,

        /// <summary>
        /// MWeb
        /// </summary>
        MWEB
    }

    /// <summary>
    /// Trade State
    /// </summary>
    public enum TradeState
    {
        /// <summary>
        /// Null
        /// </summary>
        NULL,

        /// <summary>
        /// Success
        /// </summary>
        SUCCESS,

        /// <summary>
        /// Refund
        /// </summary>
        REFUND,

        /// <summary>
        /// Not Pay
        /// </summary>
        NOTPAY,

        /// <summary>
        /// Closed
        /// </summary>
        CLOSED,

        /// <summary>
        /// Revoked
        /// </summary>
        REVOKED,

        /// <summary>
        /// User Paying
        /// </summary>
        USERPAYING,

        /// <summary>
        /// Pay Error
        /// </summary>
        PAYERROR,
    }
}
