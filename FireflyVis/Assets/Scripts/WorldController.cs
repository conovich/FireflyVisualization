using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {

	public CharacterControls myCharacter;
	public FireflySpawner myFireflySpawner;
	public DateTimeController myDateTime;
	public WeatherController myWeather;
	public TimelineVisController myTimelineVis;

	public UnitedStatesParser myUnitedStates;

	//UI
	public Text StateText;
	public Text DateText;
	public Text NumFirefliesText;

	public int CurrentNumFireflies;


	//SINGLETON
	private static WorldController _instance;
	
	public static WorldController Instance{
		get {
			return _instance;
		}
	}
	
	void Awake(){
		if(Instance == null){
			_instance = this;
		}
		else{
			Debug.Log("Instance already exists!");
		}
	}

	// Use this for initialization
	void Start () {
		myUnitedStates.Parse();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetState(UnitedState state){
		StateText.text = state.name;
		SetNumFireflies(state);
	}

	public void SetDateTimeText(string month, int day, int year){
		DateText.text = month + " " + (day.ToString()) + ", " + (year.ToString());

	}

	//CALL THIS WHEN a) WHEN CHARACTER ENTERS A NEW STATE, & b) WHEN THE DAY/WEEK CHANGES c) WHEN THE WEATHER CHANGES
	public void SetNumFireflies(UnitedState state){
		myTimelineVis.SetDotSizes();

		int monthIndex = myDateTime.currentMonth - 1;
		int weekIndex = myDateTime.GetWeekIndex((short)myDateTime.currentDay);

		int cloudyIndex = getCloudyIndex();

		int numFireflies = state.GetAvgNumFireflies(myDateTime.currentYear, monthIndex, weekIndex, cloudyIndex);

		//set current number of fireflies!
		CurrentNumFireflies = numFireflies;
		SetFireflyNumText();
	}

	public void SetFireflyNumText(){
		NumFirefliesText.text = CurrentNumFireflies.ToString() + " Fireflies";
	}

	public int getCloudyIndex(){
		int cloudyIndex = 0;
		if(myWeather.isCloudy){
			cloudyIndex = 1;
		}
		else if(myWeather.isRaining){
			cloudyIndex = 2;
		}

		return cloudyIndex;
	}

}
