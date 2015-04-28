using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {

	public CharacterControls myCharacter;
	public FireflySpawner myFireflySpawner;
	public DateTimeController myDateTime;

	public UnitedStates myUnitedStates;

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetState(string newStateText){
		StateText.text = newStateText;
	}
}
