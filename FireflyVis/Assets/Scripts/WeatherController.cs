using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeatherController : MonoBehaviour {

	public ParticleSystem Rain;
	public ParticleSystem Clouds;

	public Toggle RainToggle;
	public Toggle CloudToggle;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleRain(){
		//isRaining = !isRaining;
		if(RainToggle.isOn){
			CloudToggle.isOn = false;
			Rain.Play();
			Clouds.Play();
		}
		else{
			Rain.Stop();
			if(!CloudToggle.isOn){
				Clouds.Stop();
			}
		}

	}

	public void ToggleClouds(){
		if(CloudToggle.isOn){
			RainToggle.isOn = false;
			Rain.Stop();
			Clouds.Play();
		}
		else{
			Clouds.Stop();
		}
	}
}
