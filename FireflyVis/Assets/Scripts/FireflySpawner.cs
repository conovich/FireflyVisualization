using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FireflySpawner: MonoBehaviour {

	WorldController world { get { return WorldController.Instance; } }


	public float SpawnRadius;
	public float MovementOffset;
	public GameObject fireflyObj;

	List<Firefly> myFireflies;

	// Use this for initialization
	void Start () {
		myFireflies = new List<Firefly>();
		SpawnFireflies(world.CurrentNumFireflies);
	}

	void SpawnFireflies(int numFireflies){
		for(int i = 0; i < numFireflies; i++){
			SpawnFirefly();
		}
	}

	void SpawnFirefly(){
		Vector3 randomPos = Random.insideUnitSphere * SpawnRadius;
		if (randomPos.y < 0){
			randomPos = new Vector3(randomPos.x, -randomPos.y, randomPos.z);
		}

		if(world.myCharacter.isMovingForward){
			randomPos += world.myCharacter.transform.forward * MovementOffset;
		}
		else if(world.myCharacter.isMovingBackward){
			randomPos -= world.myCharacter.transform.forward * MovementOffset;
		}
		
		//spawn this distance from the character...
		randomPos = world.myCharacter.transform.position + randomPos;
		
		GameObject newFirely = GameObject.Instantiate(fireflyObj, randomPos, Quaternion.identity) as GameObject;
		Firefly newFireflyComponent = newFirely.GetComponent<Firefly>();
		myFireflies.Add(newFireflyComponent);
	}

	void RemoveFireflies(int numFirefliesToRemove){
		//if there are more fireflies to remove than there are fireflies, cap the number to remove
		if(numFirefliesToRemove > myFireflies.Count){
			numFirefliesToRemove = myFireflies.Count;
		}

		//remove a firefly at random until you removed the right number
		for(int i = 0; i < numFirefliesToRemove; i++){
			int randomIndex = Random.Range(0, myFireflies.Count);
			Firefly fireflyToRemove = myFireflies[randomIndex];
			RemoveFirefly(fireflyToRemove);
		}

	}

	public void RemoveFirefly(Firefly fireflyToRemove){
		myFireflies.Remove(fireflyToRemove);
		Destroy(fireflyToRemove.gameObject);
	}

	// Update is called once per frame
	void Update () {
		CheckNumFireflies();
	}

	void CheckNumFireflies(){
		if(myFireflies.Count < world.CurrentNumFireflies){ //too few, add some!
			int difference = world.CurrentNumFireflies - myFireflies.Count;
			SpawnFireflies(difference);
		}
		else if(myFireflies.Count > world.CurrentNumFireflies){ //too many -- get rid of some!
			int difference = myFireflies.Count - world.CurrentNumFireflies;
			RemoveFireflies(difference);
		}
	}
}
