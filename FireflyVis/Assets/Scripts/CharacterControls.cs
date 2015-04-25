using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

	//ROTATION
	float absMaxAngle = 0.04f;
	float rotIncrement = 0.015f;
	
	float currentRotAngle = 0.0f;
	
	float stopEpsilon = 0.003f;


	//MOVEMENT
	bool steppedLeftLast = false;
	bool hasStepped = false;
	bool isStepping = false;
	float stepSize = 2.0f;
	float stepSpeed = 10f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
	}

	void GetInput(){
		//rotation
		if(Input.GetKey(KeyCode.A)){
			Debug.Log ("RotateLeft");
			RotateLeft();
		}
		else if(Input.GetKey(KeyCode.D)){
			Debug.Log ("RotateRight");
			RotateRight();
		}
		else{
			StopRotation();
		}

		//movement
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if( (hasStepped == false || steppedLeftLast == false) && isStepping == false){
				isStepping = true;
				hasStepped = true;
				StartCoroutine(StepLeft ());
			}
		}
		else if(Input.GetKey(KeyCode.RightArrow)){
			if( (hasStepped == false || steppedLeftLast == true) && isStepping == false){
				isStepping = true;
				hasStepped = true;
				StartCoroutine(StepRight());
			}
		}
		else{
			StopRotation();
		}
	}

	void RotateLeft(){
		if(currentRotAngle > 0){
			currentRotAngle = 0;
		}

		if(currentRotAngle > -absMaxAngle){
			currentRotAngle -= rotIncrement*Time.deltaTime;
		}
			
		if(currentRotAngle < -absMaxAngle){
			currentRotAngle = -absMaxAngle;
		}
			
		Rotate ();
	}

	void RotateRight(){
		if(currentRotAngle < 0){
			currentRotAngle = 0;
		}
		
		if(currentRotAngle < absMaxAngle){
			currentRotAngle += rotIncrement*Time.deltaTime;
		}
		
		if(currentRotAngle > absMaxAngle){
			currentRotAngle = absMaxAngle;
		}
		
		Rotate ();
	}

	void Rotate(){
		transform.RotateAround(transform.position, Vector3.up, currentRotAngle);
	}

	void StopRotation(){
		if(currentRotAngle < 0){
			currentRotAngle += 2f*rotIncrement*Time.deltaTime;
		}
		else if(currentRotAngle > 0){
			currentRotAngle -= 2f*rotIncrement*Time.deltaTime;
		}
		
		if(currentRotAngle > (0.0f - stopEpsilon) && currentRotAngle < (0.0f + stopEpsilon)){
			currentRotAngle = 0;
		}
		
		Rotate();
	}


	IEnumerator StepRight(){
		steppedLeftLast = false;
		yield return StartCoroutine(Step());
	}

	IEnumerator StepLeft(){
		steppedLeftLast = true;
		yield return StartCoroutine(Step());
	}


	//INSTEAD, add a step amount over time -- don't lerp....... then, can keep adding to the "amount left to step" variable or something!
	IEnumerator Step(){
		float distanceEpsilon = 0.02f;

		Vector3 stepPosition = transform.position + transform.forward*stepSize;

		Debug.Log("ahhh" + (transform.position - stepPosition).magnitude);

		while( (transform.position - stepPosition).magnitude > distanceEpsilon ) {
			Debug.Log("A" + transform.position);
			transform.position = Vector3.Lerp(transform.position, stepPosition, stepSpeed*Time.deltaTime);
			Debug.Log("B" + transform.position);
			yield return 0;
		}

		transform.position = stepPosition;
		isStepping = false;
		yield return 0;
	}

}
