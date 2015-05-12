using UnityEngine;
using System.Collections;

public class UniformScaleController : MonoBehaviour {
	public bool UIPingPongScale = false;

	public float scaleIncrement;
	public float speed;

	public float dotMaxScale = 0.215f;
	public float dotMinScale = 0.0289f;

	bool isLerping = false;

	// Use this for initialization
	void Start () {
		if(UIPingPongScale){
			StartCoroutine(UIPingPong(dotMaxScale));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator UIPingPong(float scale){ //JUST FOR UI.

		isLerping = true;

		RectTransform rectTransform = GetComponent<RectTransform>();

		float epsilon = 0.008f; //BE CAREFUL WITH THIS VALUE OR IT WILL PINGPONG TOO FAST AND YOU'LL GET A STACK OVERFLOW.
		Vector3 scaleVec = new Vector3(scale, scale, scale);
		while( Mathf.Abs(rectTransform.localScale.x - scale) > epsilon){
			rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, scaleVec, Time.deltaTime*speed);
			yield return 0;
		}
		
		
		rectTransform.localScale = new Vector3(scale, scale, scale);
		
		isLerping = false;

		if(scale == dotMinScale){
			StartCoroutine(UIPingPong(dotMaxScale));
		}
		else{
			StartCoroutine(UIPingPong(dotMinScale));
		}
	}


	float CalculateDotScale(int numFireflies){
		int maxNumFireflies = 50;
		
		float scale = (dotMaxScale - dotMinScale) * ((float)numFireflies / (float)maxNumFireflies);
		scale = dotMinScale + scale;
		
		return scale;
	}

	public void SetScaleBasedOnFireflies(int numFireflies){
		float scale = CalculateDotScale(numFireflies);
		SetScale(scale);
	}

	void SetScale(float scale){
		RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
		if(rectTransform != null){
			//rectTransform.localScale = new Vector3(scale, scale, scale);
			if(isLerping){
				StopCoroutine("SetRectTransformScaleOverTime");
			}

			StartCoroutine ( SetRectTransformScaleOverTime( scale, rectTransform) );
		}
		else{
			//transform.localScale = new Vector3(scale, scale, scale);
			if(isLerping){
				StopCoroutine("SetTransformScaleOverTime");
			}
			StartCoroutine ( SetTransformScaleOverTime(scale) );
		}
	}

	IEnumerator SetRectTransformScaleOverTime(float scale, RectTransform rectTransform){

		isLerping = true;

		float epsilon = 2f * scaleIncrement;
		Vector3 scaleVec = new Vector3(scale, scale, scale);
		while( Mathf.Abs(rectTransform.localScale.x - scale) > epsilon){
			rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, scaleVec, Time.deltaTime*speed);
			yield return 0;
		}


		rectTransform.localScale = new Vector3(scale, scale, scale);

		isLerping = false;
		yield return 0;
	}

	IEnumerator SetTransformScaleOverTime(float scale){
		isLerping = true;

		float epsilon = 2f * scaleIncrement;

		Vector3 scaleVec = new Vector3(scale, scale, scale);
		while( Mathf.Abs(transform.localScale.x - scale) > epsilon){
			transform.localScale = Vector3.Lerp(transform.localScale, scaleVec, Time.deltaTime*speed);
			yield return 0;
		}


		transform.localScale = new Vector3(scale, scale, scale);
		isLerping = false;
		yield return 0;
	}
}
