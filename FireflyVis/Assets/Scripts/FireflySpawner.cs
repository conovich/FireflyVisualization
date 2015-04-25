using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FireflySpawner: MonoBehaviour {

	WorldController world { get { return WorldController.Instance; } }


	public SphereCollider RadiusSphereCollider;
	public GameObject fireflyObj;

	public int NumFireflies;

	List<Firefly> myFireflies;

	// Use this for initialization
	void Start () {
		myFireflies = new List<Firefly>();
		SpawnFireflies(NumFireflies);
	}

	void SpawnFireflies(int NumFireflies){
		for(int i = 0; i < NumFireflies; i++){
			Vector3 randomPos = Random.insideUnitSphere * RadiusSphereCollider.radius;
			if (randomPos.y < 0){
				randomPos = new Vector3(randomPos.x, -randomPos.y, randomPos.z);
			}

			//spawn this distance from the character...
			randomPos = world.myCharacter.transform.position + randomPos;

			GameObject newFirely = GameObject.Instantiate(fireflyObj, randomPos, Quaternion.identity) as GameObject;
			Firefly newFireflyComponent = newFirely.GetComponent<Firefly>();
			myFireflies.Add(newFireflyComponent);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
