using Lsj.Util.Collections;
using Lsj.Util.Text;
using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace Lsj.Util.APIs.WeChat.Message.Result
{
    public class WeChatMessageResult
    {
        public bool Status => this.ParseStatus;
        public bool ParseStatus { get; private set; } = true;
        public string ErrorString { get; private set; }

        private XmlElement rootNode;
        private SafeStringToStringDictionary data;

        public string ToUserName { get; private set; }
        public string FromUserName { get; private set; }
        public int CreateTime { get; private set; }
        public long MsgID { get; private set; }

        public MsgType MsgType { get; private set; } = MsgType.NULL;
        public string LocationX { get; private set; }
        public string LocationY { get; private set; }
        public string Recognition { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string PicUrl { get; private set; }
        public string MediaID { get; private set; }
        public string Format { get; private set; }
        public string ThumbMediaID { get; private set; }
        public string Content { get; private set; }
        public string Scale { get; private set; }
        public string Label { get; private set; }
        public string Url { get; private set; }

        public EventType EventType { get; private set; } = EventType.NULL;
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string Precision { get; private set; }
        public string EventKey { get; private set; }
        public string Ticket { get; private set; }

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
                    this.data = new SafeStringToStringDictionary(this.rootNode.ChildNodes.OfType<XmlElement>().ToDictionary(x => x.Name, x => x.InnerText));

                    this.ToUserName = this.data["ToUserName"];
                    this.FromUserName = this.data["FromUserName"];
                    this.CreateTime = this.data["CreateTime"].ConvertToInt();
                    if (this.data["MsgType"] == "event")
                    {
                        switch (this.data["Event"])
                        {
                            case "subscribe":
                                this.EventType = EventType.Subscribe;
                                this.EventKey = this.data["EventKey"];
                                this.Ticket = this.data["Ticket"];
                                break;
                            case "unsubscribe":
                                this.EventType = EventType.Unsubscribe;
                                break;
                            case "SCAN":
                                this.EventType = EventType.Scan;
                                this.EventKey = this.data["EventKey"];
                                this.Ticket = this.data["Ticket"];
                                break;
                            case "LOCATION":
                                this.EventType = EventType.Location;
                                this.Latitude = this.data["Latitude"];
                                this.Longitude = this.data["Longitude"];
                                this.Precision = this.data["Precision"];
                                break;
                            case "CLICK":
                                this.EventType = EventType.Click;
                                this.EventKey = this.data["EventKey"];
                                break;
                            case "VIEW":
                                this.EventType = EventType.View;
                                this.EventKey = this.data["EventKey"];
                                break;
                            default:
                                throw new NotSupportedException("Not Supported Event");
                        }
                    }
                    else
                    {
                        this.MsgID = this.data["MsgId"].ConvertToLong();
                        switch (this.data["MsgType"])
                        {
                            case "text":
                                this.MsgType = MsgType.Text;
                                this.Content = this.data["Content"];
                                break;
                            case "image":
                                this.MsgType = MsgType.Image;
                                this.PicUrl = this.data["PicUrl"];
                                this.MediaID = this.data["MediaId"];
                                break;
                            case "voice":
                                this.MsgType = MsgType.Voice;
                                this.Recognition = this.data["Recognition"];
                                this.MediaID = this.data["MediaId"];
                                this.Format = this.data["Format"];
                                break;
                            case "video":
                                this.MsgType = MsgType.Video;
                                this.MediaID = this.data["MediaId"];
                                this.ThumbMediaID = this.data["ThumbMediaId"];
                                break;
                            case "shortvideo":
                                this.MsgType = MsgType.ShortVideo;
                                this.MediaID = this.data["MediaId"];
                                this.ThumbMediaID = this.data["ThumbMediaId"];
                                break;
                            case "location":
                                this.MsgType = MsgType.Location;
                                this.LocationX = this.data["Location_X"];
                                this.LocationY = this.data["Location_Y"];
                                this.Scale = this.data["Scale"];
                                this.Label = this.data["Label"];
                                break;
                            case "link":
                                this.MsgType = MsgType.Link;
                                this.Title = this.data["Title"];
                                this.Description = this.data["Description"];
                                this.Url = this.data["Url"];
                                break;
                            default:
                                throw new NotSupportedException("Not Supported MsgType");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this.ParseStatus = false;
                this.ErrorString = e.ToString();
            }
        }
    }
    public enum MsgType
    {
        NULL,
        Text,
        Image,
        Voice,
        Video,
        ShortVideo,
        Location,
        Link,
        Event,
    }
    public enum EventType
    {
        NULL,
        Subscribe,
        Unsubscribe,
        Scan,
        Location,
        Click,
        View,

    }

}
