using Lsj.Util.Collections;
using Lsj.Util.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Lsj.Util.APIs.WeChat.Pay
{
    /// <summary>
    /// WeChat Pay Data
    /// </summary>
    public class WeChatPayData : SafeDictionary<string, string>
    {
        /// <summary>
        /// WeChat Pay Data
        /// </summary>
        public WeChatPayData() : base()
        {
        }

        /// <summary>
        /// WeChat Pay Data
        /// </summary>
        public WeChatPayData(Dictionary<string, string> src) : base(src)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override string NullValue => string.Empty;

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected override void Set(string key, string value)
        {
            if (value == null)
            {
                throw new InvalidOperationException("Cannot Set Null Value");
            }
            base.Set(key, value);
        }

        /// <summary>
        /// Sign
        /// </summary>
        /// <param name="key"></param>
        public void Sign(string key)
        {
            var tosign = new StringBuilder();
            foreach (var item in this.OrderBy(x => x.Key))
            {
                tosign.Append($"{item.Key}={item.Value}&");
            }
            tosign.Append($"key={key}");

            this["sign"] = MD5.GetMD5String(tosign.ToString());
        }

        /// <summary>
        /// Check Sign
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool CheckSign(string key)
        {
            var tosign = new StringBuilder();
            foreach (var item in this.Where(x => x.Key != "sign").OrderBy(x => x.Key))
            {
                tosign.Append($"{item.Key}={item.Value}&");
            }
            tosign.Append($"key={key}");

            var sign = MD5.GetMD5String(tosign.ToString());
            return this["sign"] == sign;
        }

        /// <summary>
        /// To XML String
        /// </summary>
        /// <returns></returns>
        public string ToXMLString()
        {
            var document = new XmlDocument();
            var rootNode = document.CreateElement("xml");
            document.AppendChild(rootNode);

            foreach (var item in this)
            {
                var node = document.CreateElement(item.Key);
                var cData = document.CreateCDataSection(item.Value);
                node.AppendChild(cData);
                rootNode.AppendChild(node);
            }
            return document.InnerXml;
        }
    }
}
