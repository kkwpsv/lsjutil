using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    /// <summary>
    /// Base Result
    /// </summary>
    public abstract class BaseResult
    {
        /// <summary>
        /// BaseResult
        /// </summary>
        /// <param name="key"></param>
        protected BaseResult(string key)
        {
            _key = key;
        }

        /// <summary>
        /// Root Node
        /// </summary>
        protected XmlElement _rootNode;

        /// <summary>
        /// Data
        /// </summary>
        protected WeChatPayData _data;

        /// <summary>
        /// Key
        /// </summary>
        private readonly string _key;

        /// <summary>
        /// Status
        /// </summary>
        public bool Status => ParseStatus && ReturnStatus && ResultStatus && SignStatus;

        /// <summary>
        /// Error String
        /// </summary>
        public string ErrorString { get; private set; }

        /// <summary>
        /// Parse Status
        /// </summary>
        public bool ParseStatus { get; private set; } = true;

        /// <summary>
        /// Return Result
        /// </summary>
        public bool ReturnStatus { get; private set; } = false;

        /// <summary>
        /// Result Status
        /// </summary>
        public bool ResultStatus { get; private set; } = false;

        /// <summary>
        /// Sign Status
        /// </summary>
        public bool SignStatus { get; private set; } = false;

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="xml"></param>
        public void Parse(byte[] xml)
        {
            try
            {
                using var stream = new MemoryStream(xml);
                var documnet = new XmlDocument
                {
                    XmlResolver = null
                };
                documnet.Load(stream);
                _rootNode = documnet.DocumentElement;

                _data = new WeChatPayData(_rootNode.ChildNodes.OfType<XmlElement>().ToDictionary(x => x.Name, x => x.InnerText));
                if (_data["return_code"] == "SUCCESS")
                {
                    ReturnStatus = true;
                    if (_data["result_code"] == "SUCCESS")
                    {
                        ResultStatus = true;
                        if (_data.CheckSign(_key))
                        {
                            SignStatus = true;
                            ParseExtra();
                        }
                        else
                        {
                            SignStatus = false;
                        }

                    }
                    else
                    {
                        ResultStatus = false;
                    }
                }
                else
                {
                    ErrorString = _data["return_msg"];
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception e)
            {
                ParseStatus = false;
                ErrorString = e.ToString();
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected virtual void ParseExtra()
        {

        }
    }
}
