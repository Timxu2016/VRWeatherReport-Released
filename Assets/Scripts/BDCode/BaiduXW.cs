using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BDCode
{
    [XmlRoot("rss")]
    public class Rss
    {
        public Channel channel { get; set; }
    }

    [XmlRoot("channel")]
    public class Channel
    {
        public string title { get; set; }
        public BaiduImage image { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string lastBuildDate { get; set; }
        public string docs { get; set; }
        public string generator { get; set; }
        [XmlElement]
        public List<Channel_Item> item { get; set; }
    }

    public class BaiduImage
    {
        public string title { get; set; }
        public string link { get; set; }
        public string url { get; set; }
    }

    public class Channel_Item
    {
        public string title { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public string guid { get; set; }
        public string source { get; set; }
        public string author { get; set; }
        public string description { get; set; }
    }
}
