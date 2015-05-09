using UnityEngine;
using System.Collections;

public class UnitedStates : MonoBehaviour {


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
	private static UnitedStates _instance;
	
	public static UnitedStates Instance{
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
