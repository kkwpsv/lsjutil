using Lsj.Util.Collections;
using Lsj.Util.Text;
using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace Lsj.Util.APIs.WeChat.Message.Result
{
    /// <summary>
    /// WeChat Message Result
    /// </summary>
    public class WeChatMessageResult
    {
        /// <summary>
        /// Status
        /// </summary>
        public bool Status => ParseStatus;

        /// <summary>
        /// Parse Status
        /// </summary>
        public bool ParseStatus { get; private set; } = true;

        /// <summary>
        /// Error String
        /// </summary>
        public string ErrorString { get; private set; }

        private XmlElement _rootNode;
        private SafeStringToStringDictionary _data;

        /// <summary>
        /// To User Name
        /// </summary>
        public string ToUserName { get; private set; }

        /// <summary>
        /// From User Name
        /// </summary>
        public string FromUserName { get; private set; }

        /// <summary>
        /// Create Time
        /// </summary>
        public int CreateTime { get; private set; }

        /// <summary>
        /// Msg ID
        /// </summary>
        public long MsgID { get; private set; }

        /// <summary>
        /// Msg Type
        /// </summary>
        public MsgType MsgType { get; private set; } = MsgType.NULL;

        /// <summary>
        /// Location X
        /// </summary>
        public string LocationX { get; private set; }

        /// <summary>
        /// Location Y
        /// </summary>
        public string LocationY { get; private set; }

        /// <summary>
        /// Recognition
        /// </summary>
        public string Recognition { get; private set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Pic Url
        /// </summary>
        public string PicUrl { get; private set; }

        /// <summary>
        /// Media ID
        /// </summary>
        public string MediaID { get; private set; }

        /// <summary>
        /// Format
        /// </summary>
        public string Format { get; private set; }

        /// <summary>
        /// Thumb Media ID
        /// </summary>
        public string ThumbMediaID { get; private set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Scale
        /// </summary>
        public string Scale { get; private set; }

        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; private set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Event Type
        /// </summary>
        public EventType EventType { get; private set; } = EventType.NULL;

        /// <summary>
        /// Latitude
        /// </summary>
        public string Latitude { get; private set; }

        /// <summary>
        /// Longtitude
        /// </summary>
        public string Longitude { get; private set; }

        /// <summary>
        /// Precision
        /// </summary>
        public string Precision { get; private set; }

        /// <summary>
        /// Event Key
        /// </summary>
        public string EventKey { get; private set; }

        /// <summary>
        /// Ticket
        /// </summary>
        public string Ticket { get; private set; }

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
                _data = new SafeStringToStringDictionary(_rootNode.ChildNodes.OfType<XmlElement>().ToDictionary(x => x.Name, x => x.InnerText));

                ToUserName = _data["ToUserName"];
                FromUserName = _data["FromUserName"];
                CreateTime = _data["CreateTime"].ConvertToInt();
                if (_data["MsgType"] == "event")
                {
                    switch (_data["Event"])
                    {
                        case "subscribe":
                            EventType = EventType.Subscribe;
                            EventKey = _data["EventKey"];
                            Ticket = _data["Ticket"];
                            break;
                        case "unsubscribe":
                            EventType = EventType.Unsubscribe;
                            break;
                        case "SCAN":
                            EventType = EventType.Scan;
                            EventKey = _data["EventKey"];
                            Ticket = _data["Ticket"];
                            break;
                        case "LOCATION":
                            EventType = EventType.Location;
                            Latitude = _data["Latitude"];
                            Longitude = _data["Longitude"];
                            Precision = _data["Precision"];
                            break;
                        case "CLICK":
                            EventType = EventType.Click;
                            EventKey = _data["EventKey"];
                            break;
                        case "VIEW":
                            EventType = EventType.View;
                            EventKey = _data["EventKey"];
                            break;
                        default:
                            throw new NotSupportedException("Not Supported Event");
                    }
                }
                else
                {
                    MsgID = _data["MsgId"].ConvertToLong();
                    switch (_data["MsgType"])
                    {
                        case "text":
                            MsgType = MsgType.Text;
                            Content = _data["Content"];
                            break;
                        case "image":
                            MsgType = MsgType.Image;
                            PicUrl = _data["PicUrl"];
                            MediaID = _data["MediaId"];
                            break;
                        case "voice":
                            MsgType = MsgType.Voice;
                            Recognition = _data["Recognition"];
                            MediaID = _data["MediaId"];
                            Format = _data["Format"];
                            break;
                        case "video":
                            MsgType = MsgType.Video;
                            MediaID = _data["MediaId"];
                            ThumbMediaID = _data["ThumbMediaId"];
                            break;
                        case "shortvideo":
                            MsgType = MsgType.ShortVideo;
                            MediaID = _data["MediaId"];
                            ThumbMediaID = _data["ThumbMediaId"];
                            break;
                        case "location":
                            MsgType = MsgType.Location;
                            LocationX = _data["Location_X"];
                            LocationY = _data["Location_Y"];
                            Scale = _data["Scale"];
                            Label = _data["Label"];
                            break;
                        case "link":
                            MsgType = MsgType.Link;
                            Title = _data["Title"];
                            Description = _data["Description"];
                            Url = _data["Url"];
                            break;
                        default:
                            throw new NotSupportedException("Not Supported MsgType");
                    }
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
    }

    /// <summary>
    /// Msg Type
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        /// Null
        /// </summary>
        NULL,

        /// <summary>
        /// Text
        /// </summary>
        Text,

        /// <summary>
        /// Image
        /// </summary>
        Image,

        /// <summary>
        /// Voice
        /// </summary>
        Voice,

        /// <summary>
        /// Video
        /// </summary>
        Video,

        /// <summary>
        /// Short Video
        /// </summary>
        ShortVideo,

        /// <summary>
        /// Location
        /// </summary>
        Location,

        /// <summary>
        /// Link
        /// </summary>
        Link,

        /// <summary>
        /// Event
        /// </summary>
        Event,
    }

    /// <summary>
    /// Event Type
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Null
        /// </summary>
        NULL,

        /// <summary>
        /// Subscribe
        /// </summary>
        Subscribe,

        /// <summary>
        /// Unsubscribe
        /// </summary>
        Unsubscribe,

        /// <summary>
        /// Scan
        /// </summary>
        Scan,

        /// <summary>
        /// Location
        /// </summary>
        Location,

        /// <summary>
        /// Click
        /// </summary>
        Click,

        /// <summary>
        /// View
        /// </summary>
        View,
    }
}
