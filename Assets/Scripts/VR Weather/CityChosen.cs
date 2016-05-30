using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NewtonVR;

public class CityChosen : RayInterectable 
{
	private GameObject player;
	public GameObject resetPosition;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);	
	}

	public override void BeginInteraction(NVRHand hand)
	{
		base.BeginInteraction (hand);
		InteractingUpdate (hand);
	}

	public override void EndInteraction()
	{
		base.EndInteraction ();
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
		//Debug.Log ("City Chosen!");
		var ob = FindObjectsOfType<Toggle> ();
		foreach (var o in ob)
			o.isOn = false;
		GetComponentInParent<Toggle> ().isOn = true;
		player.GetComponent<WeatherManager> ().city = GetComponent<Text>().text;
		player.transform.position = resetPosition.transform.position;
	}
}
