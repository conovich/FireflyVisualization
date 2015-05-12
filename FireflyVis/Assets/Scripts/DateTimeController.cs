using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DateTimeController : MonoBehaviour {
	WorldController world { get { return WorldController.Instance; } }

	public bool isPlaying = false;
	public float dayNumber = 1; //for use in the timeline playhead


	float TimeSpeedSummer = 4;
	float TimeSpeedWinter = 20;

	public int currentYear = 2008;
	int maxYear = 2013;

	string monthName = "January"; //start with january by default
	public int currentMonth = 1;

	int maxDayJan = 31;
	int maxDayFeb08 = 29;
	int maxDayFeb12 = 29;
	int maxDayFeb09 = 28;
	int maxDayFeb10 = 28;
	int maxDayFeb11 = 28;
	int maxDayFeb13 = 28;
	int maxDayMar = 31;
	int maxDayApr = 30;
	int maxDayMay = 31;
	int maxDayJun = 30;
	int maxDayJul = 31;
	int maxDayAug = 31;
	int maxDaySep = 30;
	int maxDayOct = 31;
	int maxDayNov = 30;
	int maxDayDec = 31;
	int currentMonthMaxDay;

	public int currentWeekIndex = 0;
	public float currentDay = 1;

	public Text pauseText;


	/*
	//avg sunrise times - lincoln, nebraska.
	int[] sunriseTimes = {7,7,7,6,6,5,6,6,7,7,7,7};

	//avg sunset times - lincoln, nebraska
	int[] sunsetTimes = {5,6,7,8,8,9,9,8,7,6,5,5};
	*/

	// Use this for initialization
	void Start () {
		Init ();
	}

	void Init(){
		currentDay = 1;
		currentMonth = 1;
		currentMonthMaxDay = maxDayJan;
		currentYear = 2008;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			isPlaying = !isPlaying;
			if(isPlaying){
				pauseText.text = "[press 'p' to pause]";
			}
			else{
				pauseText.text = "[press 'p' to unpause]";
			}
		}

		if(isPlaying && world.myIntroController.currentIntroState == IntroController.IntroState.finished){
			PassTime ();
			UpdateDateTimeText();
		}
	}

	void PassTime(){
		float timeSpeed = TimeSpeedWinter;
		if(currentMonth == 5 || currentMonth == 6 || currentMonth == 7 || currentMonth == 8){
			timeSpeed = TimeSpeedSummer;
		}

		currentDay += Time.deltaTime*timeSpeed;
		dayNumber += Time.deltaTime*timeSpeed;

		int oldWeekIndex = currentWeekIndex;
		currentWeekIndex = GetWeekIndex((short)currentDay);
		if(currentWeekIndex != oldWeekIndex){
			world.SetNumFireflies(world.myCharacter.currentState);
		}

		if(currentDay > currentMonthMaxDay){ //increment the month!
			currentDay = 1;
			world.SetNumFireflies(world.myCharacter.currentState);
			SwitchToNextMonth();
			if(currentMonth == 1){ //increment the year!
				currentYear++;
				dayNumber = 1.0f;
				if(currentYear > maxYear){
					currentYear = 2008;
				}
			}
		}
	}

	void SwitchToNextMonth(){
		currentMonth++;
		switch(currentMonth){
			case 13: // if 13, means we just came from december, should switch to january
				currentMonth = 1;
				currentMonthMaxDay = maxDayJan;
				monthName = "January";
				break;
			case 2:
				monthName = "February";
				if(currentYear == 2008){
					currentMonthMaxDay = maxDayFeb08;
				}
				if(currentYear == 2009){
					currentMonthMaxDay = maxDayFeb09;
				}
				if(currentYear == 2010){
					currentMonthMaxDay = maxDayFeb10;
				}
				if(currentYear == 2011){
					currentMonthMaxDay = maxDayFeb11;
				}
				if(currentYear == 2012){
					currentMonthMaxDay = maxDayFeb12;
				}
				if(currentYear == 2013){
					currentMonthMaxDay = maxDayFeb13;
				}
				break;
			case 3:
				monthName = "March";
				currentMonthMaxDay = maxDayMar;
				break;
			case 4:
				monthName = "April";
				currentMonthMaxDay = maxDayApr;
				break;
			case 5:
				monthName = "May";
				currentMonthMaxDay = maxDayMay;
				break;
			case 6:
				monthName = "June";
				currentMonthMaxDay = maxDayJun;
				break;
			case 7:
				monthName = "July";
				currentMonthMaxDay = maxDayJul;
				break;
			case 8:
				monthName = "August";
				currentMonthMaxDay = maxDayAug;
				break;
			case 9:
				monthName = "September";
				currentMonthMaxDay = maxDaySep;
				break;
			case 10:
				monthName = "October";
				currentMonthMaxDay = maxDayOct;
				break;
			case 11:
				monthName = "November";
				currentMonthMaxDay = maxDayNov;
				break;
			case 12:
				monthName = "December";
				currentMonthMaxDay = maxDayDec;
				break;
		}
	}

	void UpdateDateTimeText(){
		WorldController.Instance.SetDateTimeText(monthName, (int)currentDay, currentYear); 
	}

	public int GetWeekIndex(int day){
		if(day <= 7){
			return 0;
		}
		else if(day <= 14){
			return 1;
		}
		else if(day <= 21){
			return 2;
		}
		else{//if(day > 14){
			return 3;
		}
		
	}

	public int GetCurrentWeekIndex(){
		return GetWeekIndex((int)currentDay);
		
	}

	public void RestartCurrentYear(){
		currentMonth = 1;
		currentDay = 0;
		dayNumber = 0;
		UpdateDateTimeText();
		world.SetNumFireflies(world.myCharacter.currentState);
	}

	public void SetYear(int year){
		if(year <= 2013 && year >= 2008){
			currentYear = year;
		}
		UpdateDateTimeText();
		world.SetNumFireflies(world.myCharacter.currentState);
	}
}
