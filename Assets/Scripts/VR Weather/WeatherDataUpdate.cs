using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BDCode;

public class WeatherDataUpdate : MonoBehaviour 
{
	[Header("Today")]
	public Text date;
	public RawImage icon;
	public Text temp;
	public Text weather;
	public Text wind;
	public Text index;
	public Text currentCity;

	[Header("Tomorrow")]
	public Text _date;
	public RawImage _icon;
	public Text _temp;

	[Header("TheDayAfterTormorrow")]
	public Text __date;
	public RawImage __icon;
	public Text __temp;

	[Header("ThreeDaysFromNow")]
	public Text ___date;
	public RawImage ___icon;
	public Text ___temp;

	private GameObject player;

	private BaiduTQ weatherData;
	private BaiduTQ oldWeatherData;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);
	}

	void Update()
	{
		weatherData = player.GetComponent<WeatherManager> ().weatherData;
		if (oldWeatherData != weatherData) 
		{
			date.text = weatherData.results [0].weather_data [0].date;
			string url = weatherData.results [0].weather_data [0].dayPictureUrl;
			StartCoroutine(DownloadUrlImage (url,icon));
			temp.text = weatherData.results [0].weather_data [0].temperature;
			weather.text = weatherData.results [0].weather_data [0].weather;
			wind.text = weatherData.results [0].weather_data [0].wind;
			index.text = "PM2.5指数为：" + weatherData.results [0].pm25;
			currentCity.text = weatherData.results [0].currentCity;

			_date.text = weatherData.results [0].weather_data [1].date;
			string _url = weatherData.results [0].weather_data [1].dayPictureUrl;
			StartCoroutine (DownloadUrlImage (_url, _icon));
			_temp.text = weatherData.results [0].weather_data [1].temperature;

			__date.text = weatherData.results [0].weather_data [2].date;
			string __url = weatherData.results [0].weather_data [2].dayPictureUrl;
			StartCoroutine (DownloadUrlImage (__url, __icon));
			__temp.text = weatherData.results [0].weather_data [2].temperature;

			___date.text = weatherData.results [0].weather_data [3].date;
			string ___url = weatherData.results [0].weather_data [3].dayPictureUrl;
			StartCoroutine (DownloadUrlImage (___url, ___icon));
			___temp.text = weatherData.results [0].weather_data [3].temperature;

			oldWeatherData = weatherData;
		}
	}

	IEnumerator DownloadUrlImage(string url, RawImage icon)//直接传递texture无法赋值，传组件才可以？
	{
		WWW www = new WWW (url);
		yield return www;
		icon.texture = www.texture;
	}
}