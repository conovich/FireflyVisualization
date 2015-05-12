using UnityEngine;
using System.Collections;

public class UniformScaleController : MonoBehaviour {
	public float scaleIncrement;
	public float speed;

	public float dotMaxScale = 0.215f;
	public float dotMinScale = 0.0289f;

	bool isLerping = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

		/*float incrementMult = 1.0f;
		float scaleDiff = rectTransform.localScale.x - scale;
		if(scaleDiff < 1){
			incrementMult = -1.0f;
		}
		else{
			Debug.Log("ahhhhh");
		}

		if(incrementMult == -1.0f){
			while( Mathf.Abs(rectTransform.localScale.x - scale) > epsilon){
				rectTransform.localScale = rectTransform.localScale + (incrementMult*scaleIncrement*Vector3.one);
				yield return 0;
			}
		}*/

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

		/*float incrementMult = 1.0f;
		float scaleDiff = transform.localScale.x - scale;
		if(scaleDiff < 1){
			incrementMult = -1.0f;
		}

		while( Mathf.Abs(transform.localScale.x - scale) > epsilon ){
			transform.localScale = transform.localScale + (incrementMult*scaleIncrement*Vector3.one);
			yield return 0;
		}*/

		transform.localScale = new Vector3(scale, scale, scale);
		isLerping = false;
		yield return 0;
	}
}
