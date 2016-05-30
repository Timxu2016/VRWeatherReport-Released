using UnityEngine;
using System.Collections;
using System;

public class SkyboxInit : MonoBehaviour 
{
	public Material nightSkyBox;
	public Material sunsetSkyBox;

	void OnEnable()
	{
		
		DateTime tmCur = DateTime.Now;

		if (tmCur.Hour < 8 || tmCur.Hour >=20) 
		{//晚上
			RenderSettings.skybox = nightSkyBox;
		} 
		else if (tmCur.Hour >= 18 && tmCur.Hour < 20) 
		{
			RenderSettings.skybox = sunsetSkyBox;
		}
		else if (tmCur.Hour>=8 && tmCur.Hour<12)
		{//上午
			RenderSettings.skybox = GetComponentInChildren<Skybox> ().material;
		}
		else
		{//下午
			RenderSettings.skybox = GetComponentInChildren<Skybox> ().material;
		} 
	}
}
