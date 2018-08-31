using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    public class BaseResult
    {
        public BaseResult(string key)
        {
            this.key = key;
        }
        protected XmlElement rootNode;
        protected WeChatPayData data;
        private string key;

        public bool Status => this.ParseStatus && this.ReturnStatus && this.ResultStatus && this.SignStatus;
        public string ErrorString { get; private set; }
        public bool ParseStatus { get; private set; } = true;
        public bool ReturnStatus { get; private set; } = false;
        public bool ResultStatus { get; private set; } = false;
        public bool SignStatus { get; private set; } = false;
        public void Parse(byte[] xml)
        {
            try
            {
                using (var stream = new MemoryStream(xml))
                {
                    var documnet = new XmlDocument();
                    documnet.XmlResolver = null;
                    documnet.Load(stream);
                    this.rootNode = documnet.DocumentElement;

                    this.data = new WeChatPayData(this.rootNode.ChildNodes.OfType<XmlElement>().ToDictionary(x => x.Name, x => x.InnerText));
                    if (this.data["return_code"] == "SUCCESS")
                    {
                        this.ReturnStatus = true;
                        if (this.data["result_code"] == "SUCCESS")
                        {
                            if (this.data.CheckSign(this.key))
                            {
                                this.SignStatus = true;
                                this.ParseExtra();
                            }
                            else
                            {
                                this.SignStatus = false;
                            }

                        }
                        else
                        {
                            this.ResultStatus = false;
                        }
                    }
                    else
                    {
                        this.ErrorString = this.data["return_msg"];
                    }
                }
            }
            catch (Exception e)
            {
                this.ParseStatus = false;
                this.ErrorString = e.ToString();
            }
        }

        protected virtual void ParseExtra()
        {

        }
    }
}
