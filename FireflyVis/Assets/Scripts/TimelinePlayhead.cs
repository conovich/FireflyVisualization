using UnityEngine;
using System.Collections;

public class TimelinePlayhead : MonoBehaviour {

	WorldController world { get { return WorldController.Instance; } }

	public RectTransform StartPosTransform;
	public RectTransform EndPosTransform;

	// Use this for initialization
	void Start () {
	
	}

	void Reset(){
		transform.position = StartPosTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		float distanceStartToEnd = Mathf.Abs(EndPosTransform.position.x - StartPosTransform.position.x);

		float newXPosFromStart = ( (world.myDateTime.dayNumber) / 365.0f ) * distanceStartToEnd; //doesn't work perfectly for leap years -- gonna let that slide for now
		transform.position = new Vector3(StartPosTransform.position.x + newXPosFromStart, transform.position.y, transform.position.z);
	}
}
