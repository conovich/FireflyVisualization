using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

	public CharacterControls myCharacter;
	public FireflySpawner myFireflySpawner;

	public UnitedStates myUnitedStates;


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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
