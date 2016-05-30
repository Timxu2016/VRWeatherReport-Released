using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour 
{
	public AudioClip clip;

	void OnEnable()
	{
		GameObject player = GameObject.FindGameObjectWithTag (Tags.player);
		player.GetComponent<AudioSource> ().clip = clip;
		player.GetComponent<AudioSource> ().Play ();
	}
}
