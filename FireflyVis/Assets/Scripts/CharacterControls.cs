using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

	//ROTATION
	float rotationSpeed = 1;
	float moveSpeed = 1;
	
	float turnIncrement = 1.0f; //in degrees
	float moveIncrement = 1.0f;


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
		float horizontalAxisInput = Input.GetAxis ("Horizontal");
		
		if ( horizontalAxisInput != 0)
		{
			Turn( turnIncrement*horizontalAxisInput*rotationSpeed );
		}

		//rotation up-down
		/*float verticalAxisInput = Input.GetAxis ("Vertical");
		
		if ( verticalAxisInput != 0)
		{
			TurnUpDown( turnIncrement*verticalAxisInput*RotationSpeed );
		}*/


		//regular movement

		float verticalAxisInput = Input.GetAxis ("Vertical");
		
		if ( verticalAxisInput != 0 ) 
		{
			//GetComponent<Rigidbody>().velocity = transform.forward*verticalAxisInput*MoveSpeed;
			Move ( moveIncrement*verticalAxisInput*moveSpeed );
		}
		else{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}

		//stepping movement
		/*if(Input.GetKeyDown(KeyCode.J)){
			if( (hasStepped == false || steppedLeftLast == false) && isStepping == false){
				isStepping = true;
				hasStepped = true;
				StartCoroutine(StepLeft ());
			}
		}
		else if(Input.GetKey(KeyCode.L)){
			if( (hasStepped == false || steppedLeftLast == true) && isStepping == false){
				isStepping = true;
				hasStepped = true;
				StartCoroutine(StepRight());
			}
		}*/
	}

	void Move( float amount ){
		transform.position += transform.forward * amount;
	}

	void Turn( float amount ){
		transform.RotateAround (transform.position, Vector3.up, amount );
	}

	/*void TurnUpDown( float amount ){
		transform.RotateAround (transform.position, Vector3.right, amount );
	}*/


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


	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "State"){
			WorldController.Instance.SetState(collision.gameObject.name);

			//TODO: set other info!!
		}
	}

}
