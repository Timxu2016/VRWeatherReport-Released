using UnityEngine;
using System.Collections;
using NewtonVR;

public class UIControl : MonoBehaviour 
{
	private NVRHand hand;
	public GameObject ui;
	public GameObject uiPosition;

	void Awake()
	{
		hand = GetComponent<NVRHand> ();
		StartCoroutine (dataUpdate());
	}

	void Update()
	{
		if (hand.UseButtonDown) 
		{
			if(ui.activeSelf == false)
			{
				UpdateUIPosition (ui);
				ui.SetActive (true);
			}
			else
				ui.SetActive (false);
		}
			
	}

	void UpdateUIPosition(GameObject ui)
	{
		ui.transform.position = uiPosition.transform.position;
		ui.transform.eulerAngles = uiPosition.transform.eulerAngles 
			- new Vector3(0,0,uiPosition.transform.eulerAngles.z);
	}

	IEnumerator dataUpdate()
	{
		yield return new WaitForSeconds (1);
		ui.SetActive(false);
	}
}
