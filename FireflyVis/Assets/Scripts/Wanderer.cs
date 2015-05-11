using UnityEngine;
using System.Collections;

//http://gamedevelopment.tutsplus.com/tutorials/understanding-steering-behaviors-seek--gamedev-849
//http://gamedevelopment.tutsplus.com/tutorials/understanding-steering-behaviors-wander--gamedev-1624

public class Wanderer : MonoBehaviour {
	
	public Transform Target;
	float timeToChangeTargetMin = 0.5f;
	float timeToChangeTargetMax = 1.0f;
	float targetMoveRadius = 2.0f;


	float maxSpeed = 0.005f;
	float maxForce = 0.0007f;
	float mass = 1.0f;
	Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		StartCoroutine(MoveSeekTarget());
	}
	
	// Update is called once per frame
	void Update () {
		SeekTarget();
	}

	void SeekTarget(){
		Vector3 steering = ComputeForces();
		
		velocity = velocity + steering;
		velocity = new Vector3 ( Mathf.Min (velocity.x, maxSpeed), Mathf.Min (velocity.y, maxSpeed), Mathf.Min (velocity.z, maxSpeed) );
		transform.position = transform.position + velocity;
	}

	Vector3 ComputeForces(){
		Vector3 desiredVelocity = (Target.position - transform.position).normalized * maxSpeed;
		Vector3 steering = desiredVelocity - velocity;
		
		steering = new Vector3 ( Mathf.Min (steering.x, maxForce), Mathf.Min (steering.y, maxForce), Mathf.Min (steering.z, maxForce) );
		if(mass != 0){
			steering = steering / mass;
		}

		return steering;
	}
	
	IEnumerator MoveSeekTarget(){
		while(true){
			float randomTimeToChange = Random.Range(timeToChangeTargetMin, timeToChangeTargetMax);

			Vector3 randomDisplacement = (Random.insideUnitSphere*targetMoveRadius);

			Target.position = transform.position + randomDisplacement;
			yield return new WaitForSeconds(randomTimeToChange);
		}
		yield return 0;
	}
}
