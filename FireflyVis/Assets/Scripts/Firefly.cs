using UnityEngine;
using System.Collections;

public class Firefly : MonoBehaviour {

	public float minWaitToComeAlive;
	public float maxWaitToComeAlive;

	// Use this for initialization
	void Start () {
		StartCoroutine(ComeAlive());
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
