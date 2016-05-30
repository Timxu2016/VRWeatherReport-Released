using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour 
{
	private Renderer myRenderer;
	private float timeToFadeOut;
	public float fadeSpeed = 0.5f;
	private bool allowToFadeScreen;
	float maxAlpha = 1.0f;
	float minAlpha = 0f;
	float targetAlpha = 1.0f;

	void Start () {
		myRenderer = GetComponent<Renderer>();
		myRenderer.material.color = Color.clear;
	}

	public void fadeScreen(float seconds)
	{
		StartCoroutine (SceneFader (seconds));
	}

	private IEnumerator SceneFader(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		//myRenderer.material.color.a 
		float a = Mathf.Lerp(myRenderer.material.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
		myRenderer.material.color =  new Color(0f,0f,0f,a);
		if (Mathf.Abs (myRenderer.material.color.a - targetAlpha) <= 0.1) 
		{
			targetAlpha = minAlpha;
			minAlpha = maxAlpha;
			maxAlpha = targetAlpha;
		}
	}
}
