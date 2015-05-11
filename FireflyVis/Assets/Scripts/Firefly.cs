using UnityEngine;
using System.Collections;

public class Firefly : MonoBehaviour {

	WorldController world { get { return WorldController.Instance; } }

	public float minWaitToComeAlive;
	public float maxWaitToComeAlive;

	// Use this for initialization
	void Start () {
		StartCoroutine(ComeAlive());
	}
	
	// Update is called once per frame
	void Update () {
		CheckDistanceFromPlayer();
	}

	public IEnumerator ComeAlive(){
		float randomTime = Random.Range(minWaitToComeAlive, maxWaitToComeAlive);

		yield return new WaitForSeconds(randomTime);

		ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();

		for(int i = 0; i < particleSystems.Length; i++){
			particleSystems[i].Play();
		}

		yield return 0;
	}

	void CheckDistanceFromPlayer(){
		float distance = (transform.position - world.myCharacter.transform.position).magnitude;

		if(distance > world.myFireflySpawner.SpawnRadius){
			world.myFireflySpawner.RemoveFirefly(GetComponent<Firefly>());
		}
	}

	void OnCollisionExit(Collision collision){

		//if(collision.gameObject.tag == "Player"){
		//	Debug.Log("OH HEY REMOVE THIS FIREFLY");
		//	world.myFireflySpawner.RemoveFirefly(GetComponent<Firefly>());
		//}

	}



}
