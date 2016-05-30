using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using UnityEngine;

namespace BDCode
{
    class Program
    {
		public static BaiduTQ getWeather(string city)
        {
			using (var client = new WebClient())
            {
                
				client.Encoding = Encoding.UTF8;
				//获取天气
				var url = "http://api.map.baidu.com/telematics/v3/weather?location=" + city + "&output=json&ak=1and0u3TOj8UpP4sLjChVIwz";
				var json = client.DownloadString(url);
                var tq = JsonConvert.DeserializeObject<BaiduTQ>(json);
				return tq;
            }
        }

		public static BaiduTQ getLocalWeather()
		{
			using (var client = new WebClient ()) 
			{
				//获取所在城市
				client.Encoding = Encoding.UTF8;
				//var url = "http://ip.taobao.com/service/getIpInfo.php?ip=" + GetLocalIP();
				var url = "http://ip.taobao.com/service/getIpInfo.php?ip=180.168.76.114";
				var json = client.DownloadString (url);
				var ip = JsonConvert.DeserializeObject<TIPData> (json);

				//return getWeather (ip.data.city);
				//获取天气
				url = "http://api.map.baidu.com/telematics/v3/weather?location=" + ip.data.city + "&output=json&ak=1and0u3TOj8UpP4sLjChVIwz";
				json = client.DownloadString (url);
				var tq = JsonConvert.DeserializeObject<BaiduTQ> (json);
				return tq;
			}
		}

		public static Rss getBaiduXW()
		{
			using (var client = new WebClient ()) 
			{
				//获取百度新闻数据
				var url = "http://news.baidu.com/n?cmd=7&loc=0&name=%B1%B1%BE%A9&tn=rss";
				client.Encoding = Encoding.GetEncoding("gb2312");
				var xml = client.DownloadString(url);
				var rss = Deserialize<Rss>(xml);
				return rss;
			}
		}

		public static string GetLocalIP()  
		{  
			string tempip = "";
			string strUrl = "http://www.ip138.com/ips138.asp";     //获得IP的网址
			Uri uri = new Uri(strUrl);
			WebRequest webreq = WebRequest.Create(uri);
			Stream s = webreq .GetResponse().GetResponseStream();
			StreamReader sr = new StreamReader(s, Encoding.Default);
			string all = sr.ReadToEnd(); 

			int start = all.IndexOf("您的IP地址是：[") + 9;
			int end = all.IndexOf("]", start);
			tempip = all.Substring(start, end - start);     //去除杂项找出ip
			Debug.Log(tempip);
			return tempip;
			 
		}
        /// <summary>
        /// 反序列化
        /// </summary>
        public static T Deserialize<T>(string xmlContent)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader strReader = new StringReader(xmlContent))
            {
                XmlReader xmlReader = XmlReader.Create(strReader);
                return (T)xs.Deserialize(xmlReader);
            }
        }
    }
}
