using UnityEngine;

public class FireLightScript : MonoBehaviour
{
	public float minIntensity = 0.25f;
	public float maxIntensity = 0.5f;
	public float minNoise = 0.0f;
	public float maxNoise = 150.0f;

	public Light fireLight;

	float random;

	void Update()
	{
		random = Random.Range(minNoise, maxNoise);
		float noise = Mathf.PerlinNoise(random, Time.time);
		fireLight.GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
	}
}