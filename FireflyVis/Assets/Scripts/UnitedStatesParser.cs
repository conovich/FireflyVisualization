using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class UnitedStatesParser : MonoBehaviour {

	WorldController world { get { return WorldController.Instance; } }

	//I/O
	StreamWriter fileWriter;
	StreamReader fileReader;
	
	public TextAsset myRawCSVFile;

	public UnitedState[] myStates;

	//ALL THE STATES...
	public UnitedState Alabama;
	public UnitedState Alaska;
	public UnitedState Arizona; 
	public UnitedState Arkansas; 
	public UnitedState California; 
	public UnitedState Colorado; 
	public UnitedState Connecticut; 
	public UnitedState Delaware; 
	public UnitedState Florida; 
	public UnitedState Georgia; 
	public UnitedState Hawaii; 
	public UnitedState Idaho; 
	public UnitedState Illinois;
	public UnitedState Indiana; 
	public UnitedState Iowa; 
	public UnitedState Kansas; 
	public UnitedState Kentucky; 
	public UnitedState Louisiana; 
	public UnitedState Maine; 
	public UnitedState Maryland; 
	public UnitedState Massachusetts; 
	public UnitedState Michigan; 
	public UnitedState Minnesota; 
	public UnitedState Mississippi; 
	public UnitedState Missouri; 
	public UnitedState Montana;
	public UnitedState Nebraska; 
	public UnitedState Nevada; 
	public UnitedState NewHampshire; 
	public UnitedState NewJersey; 
	public UnitedState NewMexico; 
	public UnitedState NewYork; 
	public UnitedState NorthCarolina; 
	public UnitedState NorthDakota; 
	public UnitedState Ohio; 
	public UnitedState Oklahoma; 
	public UnitedState Oregon; 
	public UnitedState Pennsylvania;
	public UnitedState RhodeIsland; 
	public UnitedState SouthCarolina; 
	public UnitedState SouthDakota; 
	public UnitedState Tennessee; 
	public UnitedState Texas; 
	public UnitedState Utah; 
	public UnitedState Vermont; 
	public UnitedState Virginia; 
	public UnitedState Washington; 
	public UnitedState WestVirginia; 
	public UnitedState Wisconsin; 
	public UnitedState Wyoming;





	//SINGLETON
	private static UnitedStatesParser _instance;
	
	public static UnitedStatesParser Instance{
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

		InitStateArray();
	}

	void InitStateArray(){
		myStates = GameObject.FindObjectsOfType<UnitedState>();
	}

	// Use this for initialization
	void Start () {
		
	}

	public void Parse(){
		//fileReader = new StreamReader ( myRawCSVFile.name );



		//string line = fileReader.ReadLine();
		//line = fileReader.ReadLine(); //want to skip the first line -- this is just the labels
		
		string[] lines = myRawCSVFile.text.Split('\n');

		foreach(string line in lines){

			if (line != "EOF" && line != null) {
				string[] splitLine = line.Split(',');
				
				
				if(splitLine.Length > 0){ //country
					if(splitLine[0] == "US"){

						/*
						 * int numMonths = 12;
						int numWeeksPerMonth = 4;
						clouds - clear (0), partly cloudy (1), cloudy (2) int numCloudOptions = 3;
						int numCategories = 11;
						*/
						
						/* CATEGORY INDICES: States
						 * 0 - #entries so far!
						 * 1 - temperature
						 * 2 - # seen in tens
						 * 3 - #colors seen
						 * 
						 * 
						 * 4 - city (0), suburb (1), suburb/rural mix (2), rural forest (3)
						 * 5 - no grass (1), grass (1)
						 * 6 - grass mowed - no (0), <3 times a year (1), 1-2 times/month (2),  weekly (3)
						 * 7 - fertilized - no (0), yes (1), idk (2)
						 * 8 - weed killer - no (0), yes (1), idk (3)
						 * 9 - pesticides - no (0), yes (1), idk (3)
						 */

						string stateAbbr = splitLine[1];

						if(stateAbbr != "AK" && stateAbbr != "HI"){ //we're just not gonna deal with these because I have no geometry for them....

							if(stateAbbr == "DC"){
								stateAbbr = "VA";
							}

							UnitedState currState = GetState(stateAbbr);

							if(currState != null){

								string dateTimeSighting = splitLine[2];

								string[] dateTimeSplit = dateTimeSighting.Split(' ');
								string date = dateTimeSplit[0];
								string[] dateSplit = date.Split('/');

								int month = int.Parse(dateSplit[0]);
								int day = int.Parse(dateSplit[1]);
								int weekIndex = world.myDateTime.GetWeekIndex(day);
								int year = int.Parse(dateSplit[2]);

								if(year == 8){
									year = 2008;
								}
								else if(year == 9){
									year = 2009;
								}
								else if (year == 10){
									year = 2010;
								}
								else if (year == 11){
									year = 2011;
								}
								else if (year == 12){
									year = 2012;
								}
								else if (year == 13){
									year = 2013;
								}


								string clouds = splitLine[3];
								int cloudInt = 0;
								if(clouds == "Clear"){
									cloudInt = 0;
								}
								else if (clouds == "Partly cloudy"){
									cloudInt = 0;
								}
								else if(clouds == "Foggy"){
									cloudInt = 1;
								}
								else if(clouds == "Cloudy"){
									cloudInt = 1;
								}

								string precipitate = splitLine[4];
								int precipitateInt = 0;
								if(precipitate == "None"){
									precipitateInt = 0;
								}
								else if(precipitate == "Misty"){
									precipitateInt = 0;
								}
								else if(precipitate == "Light rain"){
									precipitateInt = 1;
								}
								else if(precipitate == "Heavy rain"){
									precipitateInt = 1;
								}

								int cloudRainIndex = 0; //neither rainy, nor cloudy!
								if(precipitateInt == 1){
									cloudRainIndex = 2;
								}
								else if(cloudInt == 1){
									cloudRainIndex = 1;
								}



								int temperature = int.Parse(splitLine[5]);
								int numSeen = int.Parse(splitLine[6]);
								numSeen *= 10;
								int numColors = 0;
								if(splitLine[7] == ">3"){
									numColors = 3;
								}
								else{
									numColors = int.Parse(splitLine[7]);
								}


								/*
								string location = splitLine[8];
								int locationInt = 0;
								string grass = splitLine[9];
								string grassMowed = splitLine[10];
								string fertilized = splitLine[11];
								string weedKiller = splitLine[12];
								string pesticides = splitLine[13];
								*/
								int monthIndex = month - 1;

								//update num entries so far
								currState.AddToCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, UnitedState.NumEntriesIndex, 1);

								//now set information!
								currState.AddToCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, UnitedState.TemperatureIndex, temperature);
								currState.AddToCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, UnitedState.NumFireflyIndex, numSeen);
								currState.AddToCategoryInfo(year, monthIndex, weekIndex, cloudRainIndex, UnitedState.NumFireflyColorIndex, numColors);
								
							}
						}

					}
				}
			}
		}
	}

	public UnitedState GetState(string stateAbbr){
		switch (stateAbbr){
			case "AL":
				return Alabama;
				break;
			case "AK":
				return Alaska;
				break;
			case "AZ":
				return Arizona;
				break;
			case "AR":
				return Arkansas;
				break;
			case "CA":
				return California;
				break;
			case "CO":
				return Colorado;
				break;
			case "CT":
				return Connecticut;
				break;
			case "DE":
				return Delaware;
				break;
			case "FL":
				return Florida;
				break;
			case "GA":
				return Georgia;
				break;
			case "HI":
				return Hawaii;
				break;
			case "ID":
				return Idaho;
				break;
			case "IL":
				return Illinois;
				break;
			case "IN":
				return Indiana;
				break;
			case "IA":
				return Iowa;
				break;
			case "KS":
				return Kansas;
				break;
			case "KY":
				return Kentucky;
				break;
			case "LA":
				return Louisiana;
				break;
			case "ME":
				return Maine;
				break;
			case "MD":
				return Maryland;
				break;
			case "MA":
				return Massachusetts;
				break;
			case "MI":
				return Michigan;
				break;
			case "MN":
				return Minnesota;
				break;
			case "MS":
				return Mississippi;
				break;
			case "MO":
				return Missouri;
				break;
			case "MT":
				return Montana;
				break;
			case "NE":
				return Nebraska;
				break;
			case "NV":
				return Nevada;
				break;
			case "NH":
				return NewHampshire;
				break;
			case "NJ":
				return NewJersey;
				break;
			case "NM":
				return NewMexico;
				break;
			case "NY":
				return NewYork;
				break;
			case "NC":
				return NorthCarolina;
				break;
			case "ND":
				return NorthDakota;
				break;
			case "OH":
				return Ohio;
				break;
			case "OK":
				return Oklahoma;
				break;
			case "OR":
				return Alaska;
				break;
			case "PA":
				return Pennsylvania;
				break;
			case "RI":
				return RhodeIsland;
				break;
			case "SC":
				return SouthCarolina;
				break;
			case "SD":
				return SouthDakota;
				break;
			case "TN":
				return Tennessee;
				break;
			case "TX":
				return Texas;
				break;
			case "UT":
				return Utah;
				break;
			case "VT":
				return Vermont;
				break;
			case "VA":
				return Virginia;
				break;
			case "WA":
				return Washington;
				break;
			case "WV":
				return WestVirginia;
				break;
			case "WI":
				return Wisconsin;
				break;
			case "WY":
				return Wyoming;
				break;
		}

		Debug.Log("Didn't find right state abbreviation! " + stateAbbr);
		return null; //needed a default return...
	}

	// Update is called once per frame
	void Update () {
	
	}
}
