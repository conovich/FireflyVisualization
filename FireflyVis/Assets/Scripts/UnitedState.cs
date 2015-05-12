using UnityEngine;
using System.Collections;

public class UnitedState : MonoBehaviour {
	WorldController world { get { return WorldController.Instance; } }

	public UniformScaleController stateDot;

	string stateName;
	public const int NumEntriesIndex = 0;
	public const int TemperatureIndex = 1;
	public const int NumFireflyIndex = 2;
	public const int NumFireflyColorIndex = 3;
	/*
	 * int numMonths = 12;
	int numWeeksPerMonth = 4;
	clouds - clear (0), partly cloudy (1), cloudy (2) int numCloudOptions = 3;
	int numCategories = 11;
	*/

	int numMonths = 12;
	int numWeeksPerMonth = 4;
	int numCloudRainOptions = 3; //clear, cloudy, rainy
	int numCategories;
	//[numMonths, numWeeksPerMonth, numCloudOptions, numCategories]

	public int[,,,] infoArray2008;
	public int[,,,] infoArray2009;
	public int[,,,] infoArray2010;
	public int[,,,] infoArray2011;
	public int[,,,] infoArray2012;
	public int[,,,] infoArray2013;

	bool areArraysInitialized = false;

	UnitedState(string name){
		stateName = name;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeArrays(){
		infoArray2008 = new int[12, 4, 3, 10];
		infoArray2009 = new int[12, 4, 3, 10];
		infoArray2010 = new int[12, 4, 3, 10];
		infoArray2011 = new int[12, 4, 3, 10];
		infoArray2012 = new int[12, 4, 3, 10];
		infoArray2013 = new int[12, 4, 3, 10];

		for(int i = 0; i < 12; i++){
			for(int j = 0; j < 4; j++){
				for(int k = 0; k < 3; k++){
					for(int l = 0; l < 10; l++){
						infoArray2008[i,j,k,l] = 0;
					}
				}
			}
		}

		for(int i = 0; i < 12; i++){
			for(int j = 0; j < 4; j++){
				for(int k = 0; k < 3; k++){
					for(int l = 0; l < 10; l++){
						infoArray2009[i,j,k,l] = 0;
					}
				}
			}
		}

		for(int i = 0; i < 12; i++){
			for(int j = 0; j < 4; j++){
				for(int k = 0; k < 3; k++){
					for(int l = 0; l < 10; l++){
						infoArray2010[i,j,k,l] = 0;
					}
				}
			}
		}

		for(int i = 0; i < 12; i++){
			for(int j = 0; j < 4; j++){
				for(int k = 0; k < 3; k++){
					for(int l = 0; l < 10; l++){
						infoArray2011[i,j,k,l] = 0;
					}
				}
			}
		}

		for(int i = 0; i < 12; i++){
			for(int j = 0; j < 4; j++){
				for(int k = 0; k < 3; k++){
					for(int l = 0; l < 10; l++){
						infoArray2012[i,j,k,l] = 0;
					}
				}
			}
		}

		for(int i = 0; i < 12; i++){
			for(int j = 0; j < 4; j++){
				for(int k = 0; k < 3; k++){
					for(int l = 0; l < 10; l++){
						infoArray2013[i,j,k,l] = 0;
					}
				}
			}
		}


		areArraysInitialized = true;
	}

	//CALL THIS WHEN THE MONTH CHANGES AND WHEN THE CHARACTER ENTERS A NEW STATE
	public void ChangeDotScale(){
		int numFireflies = GetAvgNumFirefliesCurrent();
		if(stateDot == null){
			Debug.Log("No state dot: " + gameObject.name);
			stateDot = GetComponentInChildren<UniformScaleController>();
		}
		stateDot.SetScaleBasedOnFireflies(numFireflies);
	}

	public void AddToCategoryInfo(int year, int monthIndex, int weekIndex, int cloudRainIndex, int categoryIndex, int info){
		if(!areArraysInitialized){
			InitializeArrays();
		}

		switch (year){
			case 2008:
				infoArray2008[monthIndex, weekIndex, cloudRainIndex, categoryIndex] += info;
				break;
			case 2009:
				infoArray2009[monthIndex, weekIndex, cloudRainIndex, categoryIndex] += info;
				break;
			case 2010:
				infoArray2010[monthIndex, weekIndex, cloudRainIndex, categoryIndex] += info;
				break;
			case 2011:
				infoArray2011[monthIndex, weekIndex, cloudRainIndex, categoryIndex] += info;
				break;
			case 2012:
				infoArray2012[monthIndex, weekIndex, cloudRainIndex, categoryIndex] += info;
				break;
			case 2013:
				infoArray2013[monthIndex, weekIndex, cloudRainIndex, categoryIndex] += info;
				break;
		}
	}

	public int GetCategoryInfo(int year, int monthIndex, int weekIndex, int cloudRainIndex, int categoryIndex){
		if(!areArraysInitialized){
			InitializeArrays();
		}

		int info = 0;
		switch (year){
			case 2008:
				info = infoArray2008[monthIndex, weekIndex, cloudRainIndex, categoryIndex];
				break;
			case 2009:
				info = infoArray2009[monthIndex, weekIndex, cloudRainIndex, categoryIndex];
				break;
			case 2010:
				info = infoArray2010[monthIndex, weekIndex, cloudRainIndex, categoryIndex];
				break;
			case 2011:
				info = infoArray2011[monthIndex, weekIndex, cloudRainIndex, categoryIndex];
				break;
			case 2012:
				info = infoArray2012[monthIndex, weekIndex, cloudRainIndex, categoryIndex];
				break;
			case 2013:
				info = infoArray2013[monthIndex, weekIndex, cloudRainIndex, categoryIndex];
				break;
		}

		return info;
	}

	int GetNumEntries(int year, int monthIndex, int weekIndex, int cloudRainIndex){
		return GetCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, NumEntriesIndex);
	}
	
	public int GetAvgNumFireflies(int year, int monthIndex, int weekIndex, int cloudRainIndex){ //monthIndex and weekIndex should be one less
		int numEntries = GetNumEntries(year, monthIndex, weekIndex, cloudRainIndex);
		int numFireflies = GetCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, NumFireflyIndex);

		if(numEntries == 0){
			return 0;
		}

		return (int)(numFireflies / numEntries);
	}

	public int GetAvgNumFirefliesMONTH(int year, int monthIndex, int cloudRainIndex){
		int numFirefliesWeek0 = GetAvgNumFireflies(year, monthIndex, 0, cloudRainIndex);
		int numFirefliesWeek1 = GetAvgNumFireflies(year, monthIndex, 1, cloudRainIndex);
		int numFirefliesWeek2 = GetAvgNumFireflies(year, monthIndex, 2, cloudRainIndex);
		int numFirefliesWeek3 = GetAvgNumFireflies(year, monthIndex, 3, cloudRainIndex);

		float average = ((float)numFirefliesWeek0) + ((float)numFirefliesWeek1) + ((float)numFirefliesWeek2) + ((float)numFirefliesWeek3);
		average = average / 4.0f;
		return (int)average;
	}

	public int GetAvgNumFirefliesMONTHCurrent(){
		return GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, world.myDateTime.currentMonth - 1, world.getCloudyIndex());
	}

	public int GetAvgNumFirefliesCurrent(){
		return GetAvgNumFireflies(world.myDateTime.currentYear, world.myDateTime.currentMonth - 1, world.myDateTime.GetCurrentWeekIndex(), world.getCloudyIndex());
	}

	public int GetAvgTemp(int year, int monthIndex, int weekIndex, int cloudRainIndex){ //monthIndex and weekIndex should be one less
		int numEntries = GetNumEntries(year, monthIndex, weekIndex, cloudRainIndex);
		int numFireflies = GetCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, TemperatureIndex);

		return (int)(numFireflies / numEntries);
	}

	public int GetAvgColors(int year, int monthIndex, int weekIndex, int cloudRainIndex){ //monthIndex and weekIndex should be one less
		int numEntries = GetNumEntries(year, monthIndex, weekIndex, cloudRainIndex);
		int numColors = GetCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, NumFireflyColorIndex);

		float numColorsRoundedUp = Mathf.Ceil( ((float)numColors) / ((float)numEntries) );

		return ((int)numColorsRoundedUp);
	}
}
