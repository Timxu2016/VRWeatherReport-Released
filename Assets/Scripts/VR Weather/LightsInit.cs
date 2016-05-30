using UnityEngine;
using System.Collections;
using System;

public class LightsInit : MonoBehaviour 
{
	public GameObject lightHouse;
	public float rotationSpeed;

	void OnEnable()
	{
		DateTime tmCur = DateTime.Now;
		/*
		this.gameObject.SetActive(true);
		RenderSettings.ambientIntensity = 0.4f;
*/


		if ( tmCur.Hour < 8 || tmCur.Hour > 18 )
		{//晚上
			this.gameObject.SetActive(true);
			RenderSettings.ambientIntensity = 0.4f;
		}
		else if (tmCur.Hour >= 8 && tmCur.Hour < 12)
		{//上午
			this.gameObject.SetActive(false);
			RenderSettings.ambientIntensity = 0.4f;
		}
		else
		{//下午
			this.gameObject.SetActive(false);
			RenderSettings.ambientIntensity = 0.4f;
		} 

	}

	void Update()
	{
		lightHouseRotate ();
	}

	void lightHouseRotate ()
	{
		lightHouse.transform.Rotate (0,rotationSpeed * Time.deltaTime,0);
	}
}
