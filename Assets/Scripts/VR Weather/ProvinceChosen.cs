using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NewtonVR;

public class ProvinceChosen : RayInterectable 
{
	//public GameObject showPosition;
	//public GameObject screenFader;
	public Text provinceName;
	public Text[] cityNameList;

	//private Vector3 restorePosition;
	private Color restoreColor;
	private GameObject player;
	//private GameObject biggerProvince;
	//private GameObject weatherBoard;

	void Awake()
    {
		//restorePosition = transform.position;
		restoreColor = GetComponent<Renderer> ().material.color;
		player = GameObject.FindGameObjectWithTag (Tags.player);
		//weatherBoard = GameObject.FindGameObjectWithTag (Tags.weatherBoard);
    }

	public override void BeginInteraction(NVRHand hand)
	{
		base.BeginInteraction (hand);
		/*
		if (biggerProvince == null) 
		{
			biggerProvince = Instantiate (this.gameObject);
			biggerProvince.transform.position = showPosition.transform.position;
			biggerProvince.transform.rotation = this.transform.rotation;
			biggerProvince.transform.localScale = 2 * Vector3.one;
			foreach(Collider collider in biggerProvince.GetComponents <Collider> ())
				collider.enabled = false;
		}
		*/
		InteractingUpdate (hand);
		GetComponent<Renderer> ().material.color = new Color (1.0f,0.0f,0.0f);
		//transform.Rotate (new Vector3 (Random.Range(-5.0f, +5.0f), Random.Range(-5.0f, +5.0f), Random.Range(-5.0f, +5.0f)) * 2 * Time.deltaTime);
	}

	public override void EndInteraction()
	{
		base.EndInteraction ();
		//Destroy (biggerProvince);
		GetComponent<Renderer> ().material.color = restoreColor;
		/*transform.position = restorePosition;
		transform.localScale = Vector3.one;*/
	}

	public override void InteractingUpdate(NVRHand hand)
	{
		if (hand.UseButtonUp == true)
		{
			UseButtonUp();
		}

		if (hand.UseButtonDown == true)
		{
			UseButtonDown();
		}
	}

	public override void UseButtonUp()
	{

	}

	public override void UseButtonDown()
	{
		//screenFader.GetComponent<ScreenFader> ().fadeScreen (3f);
		var ob = FindObjectsOfType<Toggle> ();
		foreach (var o in ob)
			o.isOn = false;
		player.GetComponent<WeatherManager>().UpdateCityList(this.name);
	}
}
