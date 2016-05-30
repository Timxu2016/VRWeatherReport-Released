using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour 
{
	void OnEnable()
	{
		GameObject mainCamera = GameObject.FindGameObjectWithTag (Tags.mainCamera);
		transform.SetParent(mainCamera.transform);
	}
}
