using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Collections;
using BDCode;
using UnityEngine.UI;


public class WeatherManager : MonoBehaviour 
{
	public string city;
	public string oldCity;
	public BaiduTQ weatherData;

	//public GameObject nightPrefab;
	public GameObject sunnyPrefab;
	public GameObject cloudyPrefab;
	public GameObject showerPrefab;
	public GameObject littleRainyPrefab;
	public GameObject moderateRainyPrefab;
	public GameObject heaveyRainyPrefab;
	public GameObject rainStormPrefab;
	public GameObject thundershowerPrefab;
	public GameObject snowPrefab;

	public Text provinceName;
	public Text[] cityNameList;

	void Awake () 
	{
		city = Program.getLocalWeather ().results [0].currentCity;
		oldCity = city;

		UpdateCityList (city);
		UpdateCity (city);
		UpdateWeather (city);

	}

	void Update()
	{
		if (isCityUpdate ()) 
		{
			UpdateCity (city);
			UpdateWeather(city);
		}
	}

	bool isCityUpdate()
	{
		if (oldCity == city)
			return false;
		else 
		{			
			oldCity = city;
			return true;
		}
	}

	public void UpdateCityList(string info)//根据info获取整个省份城市列表并更新
	{
		foreach (Province pro in China.china)
		{
			if (pro.capital == info||pro.province == info) //省会城市
			{
				provinceName.text = pro.province;
				cityNameList [0].text = pro.capital;
				for (int i = 0; i < pro.cities.Length; i++)//暂且只有两个城市
					cityNameList [i + 1].text = pro.cities [i];
			}
				
			foreach (string c in pro.cities) 
			{
				if (c == info) //非省会城市
				{
					provinceName.text = pro.province;
					cityNameList [0].text = pro.capital;
					for (int i = 0; i < pro.cities.Length; i++)//暂且只有两个城市
						cityNameList [i + 1].text = pro.cities [i];
				}					
			}				
		}
	}

	void UpdateCity(string city)
	{		
		CityType type = CityType.Seashore;
		GameObject model = null;
		GameObject oldModel = GameObject.FindGameObjectWithTag (Tags.cityModel);
		if ( oldModel != null)
			Destroy (oldModel);

		foreach (Province pro in China.china)
		{
			if(pro.capital == city)
				type = pro.type;
			foreach (string c in pro.cities) 
			{
				if (c == city) //非省会城市
				{
					type = pro.type;
				}					
			}		
		}

		switch(type)
		{
		case CityType.Commercial:
			model = Instantiate (Resources.Load("CommercialCity")) as GameObject;break;
		case CityType.Seashore:
			model = Instantiate(Resources.Load("Seashore")) as GameObject;break;
		case CityType.Travel:
			model = Instantiate(Resources.Load("TravelCity")) as GameObject;break;
		default:
			model = Instantiate(Resources.Load("Seashore")) as GameObject;break;
		}
		//UnityEngine.SceneManagement.SceneManager.LoadScene(city);
	}

	//----change weather params
	void UpdateWeather(string city)
	{				
		//Destroy old weather feature
		GameObject oldWeatherFeature = GameObject.FindGameObjectWithTag (Tags.weatherFeatures);
		if ( oldWeatherFeature != null)
			Destroy (oldWeatherFeature);

		weatherData = Program.getWeather (city);
		var weather = weatherData.results [0].weather_data [0].weather;
		//只提取转之前的主天气
		if (weather.IndexOf ("转") != -1)
		{
			weather = weather.Remove (weather.IndexOf ("转"));
			Debug.Log ("Updateing weather in " + city + ": " + weather);
		}



		switch (weather)
		{
		case("晴"):
			GameObject Sunny = Instantiate (sunnyPrefab) as GameObject;
			break;
		case("阴"):
		case("霾"):
		case("多云"):
			GameObject Cloudy = Instantiate (cloudyPrefab) as GameObject;
			break;
		case("阵雨"):
			GameObject shower = Instantiate (littleRainyPrefab) as GameObject;
			break;
		case("小雨"):
			GameObject littleRain = Instantiate (littleRainyPrefab) as GameObject;
			break;
		case("中雨"):
			GameObject moderateRain = Instantiate (moderateRainyPrefab) as GameObject;
			break;
		case("大雨"):
			GameObject heaveyRain = Instantiate (heaveyRainyPrefab) as GameObject;
			break;
		case("暴雨"):
		case("特大暴雨"):
			GameObject rainStorm = Instantiate (rainStormPrefab) as GameObject;
			break;
		case("雷阵雨"):
			GameObject Thundershower = Instantiate (thundershowerPrefab) as GameObject;
			break;
		case("雪"):
			GameObject Snow = Instantiate (snowPrefab) as GameObject;
			break;
		case("雾"):
			GameObject Fog = Instantiate (snowPrefab) as GameObject;
			break;
		case("沙尘暴"):
			GameObject Sandstorm = Instantiate (snowPrefab) as GameObject;
			break;
		default:
			break;
		}
	}
}
