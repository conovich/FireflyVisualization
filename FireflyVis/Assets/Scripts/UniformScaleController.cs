using UnityEngine;
using System.Collections;

public class UniformScaleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetScale(float scale){
		RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
		rectTransform.localScale = new Vector3(scale, scale, scale);
	}
}
