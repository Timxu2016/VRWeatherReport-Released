using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum CityType
{
	Commercial,
	Travel,
	Seashore,
}

public class Province
{
	public string province{ get; set;}
	public string capital{ get; set;}
	public string[] cities{ get; set;}
	public CityType type{ get; set;}
}

public class China
{
	public static Province[] china = {
		new Province{ 
			province = "安徽省", 
			capital = "合肥市", 
			cities = new string[]{"巢湖市"," "}, 
			type = CityType.Commercial },
		new Province{ 
			province = "黑龙江省", 
			capital = "哈尔滨市", 
			cities = new string[]{"齐齐哈尔市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "吉林省", 
			capital = "长春市", 
			cities = new string[]{"吉林市"}, 
			type = CityType.Commercial },	
		new Province{ 
			province = "内蒙古", 
			capital = "呼和浩特市", 
			cities = new string[]{"包头包头市"}, 
			type = CityType.Travel },
		new Province{ 
			province = "辽宁省", 
			capital = "沈阳市", 
			cities = new string[]{"大连市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "河北省", 
			capital = "石家庄市", 
			cities = new string[]{"唐山市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "河南省", 
			capital = "郑州市", 
			cities = new string[]{"焦作市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "天津市", 
			capital = "天津市", 
			cities = new string[]{" "}, 
			type = CityType.Seashore },
		new Province{ 
			province = "山东省", 
			capital = "济南市", 
			cities = new string[]{"青岛市"}, 
			type = CityType.Seashore },
		new Province{ 
			province = "山西省", 
			capital = "太原市", 
			cities = new string[]{"大同市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "陕西省", 
			capital = "西安市", 
			cities = new string[]{"延安市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "宁夏", 
			capital = "银川市", 
			cities = new string[]{"固原市"}, 
			type = CityType.Travel },
		new Province{ 
			province = "新疆", 
			capital = "乌鲁木齐市", 
			cities = new string[]{"克拉玛依市"}, 
			type = CityType.Travel },
		new Province{ 
			province = "西藏", 
			capital = "拉萨市", 
			cities = new string[]{"昌都县"}, 
			type = CityType.Travel },
		new Province{ 
			province = "云南省", 
			capital = "昆明市", 
			cities = new string[]{"大理市"}, 
			type = CityType.Travel },
		new Province{ 
			province = "四川省", 
			capital = "成都市", 
			cities = new string[]{"绵阳市"}, 
			type = CityType.Travel },
		new Province{ 
			province = "重庆市", 
			capital = "重庆市", 
			cities = new string[]{" "}, 
			type = CityType.Travel },
		new Province{ 
			province = "湖北省", 
			capital = "武汉市", 
			cities = new string[]{"荆门市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "福建省", 
			capital = "福州市", 
			cities = new string[]{"泉州市"}, 
			type = CityType.Seashore },
		new Province{ 
			province = "广东省", 
			capital = "广州市", 
			cities = new string[]{"深圳市"}, 
			type = CityType.Seashore },
		new Province{ 
			province = "湖南省", 
			capital = "长沙市", 
			cities = new string[]{"张家界市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "台湾", 
			capital = "台北市", 
			cities = new string[]{"高雄市"}, 
			type = CityType.Seashore },
		new Province{ 
			province = "江西省", 
			capital = "南昌市", 
			cities = new string[]{"景德镇市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "贵州省", 
			capital = "贵阳市", 
			cities = new string[]{"遵义市"}, 
			type = CityType.Travel },
		new Province{ 
			province = "海南省", 
			capital = "三亚市", 
			cities = new string[]{"海口市"}, 
			type = CityType.Seashore },
		new Province{ 
			province = "青海省", 
			capital = "西宁市", 
			cities = new string[]{""}, 
			type = CityType.Travel },
		new Province{ 
			province = "甘肃省", 
			capital = "兰州市", 
			cities = new string[]{"天水市"}, 
			type = CityType.Travel },
		new Province{ 
			province = "上海市", 
			capital = "上海市", 
			cities = new string[]{" "}, 
			type = CityType.Commercial },
		new Province{ 
			province = "北京市", 
			capital = "北京市", 
			cities = new string[]{" "}, 
			type = CityType.Commercial },
		new Province{ 
			province = "广西", 
			capital = "南宁市", 
			cities = new string[]{"桂林市"}, 
			type = CityType.Travel },	
		new Province{ 
			province = "江苏省", 
			capital = "南京市", 
			cities = new string[]{"无锡市"}, 
			type = CityType.Commercial },
		new Province{ 
			province = "浙江省", 
			capital = "杭州市", 
			cities = new string[]{"宁波市"}, 
			type = CityType.Seashore },
		};

	/*public static string GetProvince(string city)
	{
		foreach(Province pro in china)
		{
			if (pro.capital == city)
				return pro.province;
		}
	}
	*/
}



