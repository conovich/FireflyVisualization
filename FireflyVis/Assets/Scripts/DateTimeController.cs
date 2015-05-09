using UnityEngine;
using System.Collections;

public class DateTimeController : MonoBehaviour {

	float TimeSpeed = 10;

	int currentYear = 2008;
	int maxYear = 2013;

	string monthName = "January"; //start with january by default
	int currentMonth = 1;

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


	float currentDay = 1;



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
		PassTime ();
		UpdateDateTimeText();
	}

	void PassTime(){
		currentDay += Time.deltaTime*TimeSpeed;
				if(currentDay > currentMonthMaxDay){
					currentDay = 1;
					SwitchToNextMonth();
					if(currentMonth == 1){
						currentYear++;
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
}
