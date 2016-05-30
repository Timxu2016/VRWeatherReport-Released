using UnityEngine;
using System.Collections;

public static class ProvinceInfo 
{
	public static string getCapital(string province)
	{
		switch (province) 
		{
		case "安徽省":
			return "合肥市";
		case "黑龙江省":
			return "哈尔滨市";
		case "吉林省":
			return "长春市";
		case "内蒙古":
			return "呼和浩特市";
		case "辽宁省":
			return "沈阳市";
		case "北京市":
			return "北京市";
		case "河北省":
			return "石家庄市";
		case "河南省":
			return "郑州市";
		case "天津市":
			return "天津市";
		case "山东省":
			return "济南市";
		case "山西省":
			return "太原市";
		case "陕西省":
			return "西安市";
		case "宁夏省":
			return "银川市";
		case "新疆":
			return "乌鲁木齐市";
		case "西藏":
			return "拉萨市";
		case "云南省":
			return "昆明市";
		case "四川省":
			return "成都市";
		case "重庆市":
			return "重庆市";
		case "湖北省":
			return "武汉市";
		case "江苏省":
			return "南京市";
		case "福建省":
			return "福州市";
		case "浙江省":
			return "杭州市";
		case "广东省":
			return "广州市";
		case "上海市":
			return "上海市";
		case "湖南省":
			return "长沙市";
		case "广西省":
			return "南宁市";
		case "台湾":
			return "台北市";
		case "江西省":
			return "南昌市";
		case "贵州省":
			return "贵阳市";
		case "海南省":
			return "三亚市";
		case "青海省":
			return "西宁市";
		case "甘肃省":
			return "兰州市";
		default:
			return "No such province in china! Name wrong!";
		}
	}

	public static string getProvince(string capital)
	{
		switch (capital) 
		{
		case "合肥市":
			return "安徽省";
		case "哈尔滨市":
			return "黑龙江省";
		case "长春市":
			return "吉林省";
		case "呼和浩特市":
			return "内蒙古";
		case "沈阳市":
			return "辽宁省";
		case "北京市":
			return "北京市";
		case "石家庄市":
			return "河北省";
		case "天津市":
			return "天津市";
		case "济南市":
			return "山东省";
		case "太原市":
			return "山西省";
		case "西安市":
			return "陕西省";
		case "银川市":
			return "宁夏";
		case "乌鲁木齐市":
			return "新疆";
		case "拉萨市":
			return "西藏";
		case "昆明市":
			return "云南省";
		case "成都市":
			return "四川省";
		case "重庆市":
			return "重庆市";
		case "武汉市":
			return "湖北省";
		case "南京市":
			return "江苏省";
		case "福州市":
			return "福建省";
		case "广州市":
			return "广东省";
		case "上海市":
			return "上海市";
		case "长沙市":
			return "湖南省";
		case "南宁市":
			return "广西";
		case "台北市":
			return "台湾";
		case "南昌市":
			return "江西省";
		case "贵阳市":
			return "贵州省";
		case "三亚市":
			return "海南省";
		case "杭州市":
			return "浙江省";
		case "西宁市":
			return "青海省";
		case "兰州市":
			return "甘肃省";
		default:
			return "No such capital in china! Name wrong!";
		}
	}

	public static string getCityList(string province)
	{
		return null;
	}
}
