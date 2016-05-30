using UnityEngine;
using System.Collections;
using NewtonVR;

public class ControllerRaycaster : MonoBehaviour 
{
    private RaycastHit hit;
    private LineRenderer ray;
	private RayInterectable currentlyRayInterecting = null;
	private RayInterectable previousRayInterecting;

	public Color lineColor;
	public float lineWidth = 0.02f;
	//public GameObject reachableArea;
	public GameObject destinationPrefab;
	public Transform resetPosition;

	private LineRenderer line;
	private NVRHand hand;
	private Renderer[] rd;

    void Awake()
    {
        ray = GetComponent<LineRenderer>();    
		previousRayInterecting = currentlyRayInterecting;
		hand = GetComponent<NVRHand>();
    }
		
    void Update()
    {        
		var deviceIndex = (int)GetComponent<SteamVR_TrackedObject> ().index;
		if (deviceIndex != -1 && SteamVR_Controller.Input (deviceIndex).GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu)) 
		{
			ResetPosition ();
		}

		ray.material.SetColor("_Color", lineColor);
		ray.SetColors(lineColor, lineColor);
		ray.SetWidth(lineWidth, lineWidth);


		//ray.SetPosition(0, transform.position);
		Vector3 endPoint;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 200f))
        {
			//ray.SetPosition(1, hit.point);
			currentlyRayInterecting = hit.transform.GetComponent<RayInterectable> ();
			//Debug.Log (currentlyRayInterecting);
			if (currentlyRayInterecting != null) //射到省份
			{               
				if (previousRayInterecting == currentlyRayInterecting) 
				{//同一个省份
					currentlyRayInterecting.BeginInteraction (GetComponent<NVRHand> ());
				}
				else //从一个省份移到另一个省份
				{
					//Debug.Log (previousRayInterecting);
					//Debug.Log (currentlyRayInterecting);
					currentlyRayInterecting.BeginInteraction (GetComponent<NVRHand> ());
					if(previousRayInterecting!=null)
						previousRayInterecting.EndInteraction();
				}
				previousRayInterecting = currentlyRayInterecting;
			} 
			else//射到非省份物体上 
			{
				if(previousRayInterecting!=null)
					previousRayInterecting.EndInteraction ();
			}

			endPoint = hit.point;

			var deviceIndex2 = (int)GetComponent<SteamVR_TrackedObject> ().index;
			if (deviceIndex2 != -1 && SteamVR_Controller.Input (deviceIndex2).GetPress(SteamVR_Controller.ButtonMask.Touchpad)) 
			{
				if (currentlyRayInterecting == null) 
				{
					destinationPrefab.transform.position = endPoint + new Vector3 (0, 0.01f, 0);
					destinationPrefab.transform.eulerAngles = new Vector3 (90f, transform.eulerAngles.y, 0);
				}
			} 
			else if(SteamVR_Controller.Input (deviceIndex2).GetPressUp (SteamVR_Controller.ButtonMask.Touchpad))
			{
				if (currentlyRayInterecting == null) 
				{
					Vector3 offset = NVRPlayer.Instance.Head.transform.position - NVRPlayer.Instance.transform.position;
					offset.y = 0;
					NVRPlayer.Instance.transform.position = hit.point - offset;
					destinationPrefab.transform.position = new Vector3 (1000f, -100f, 1000f);
				}
			}
		}
		else
		{
			endPoint = this.transform.position + (this.transform.forward * 1000f);
		}
			
		ray.SetPositions(new Vector3[] { this.transform.position, endPoint });
	}

	public void ResetPosition()
	{
		NVRPlayer.Instance.transform.position = resetPosition.position;
	}
}