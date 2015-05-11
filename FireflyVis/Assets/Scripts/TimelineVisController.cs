using UnityEngine;
using System.Collections;

public class TimelineVisController : MonoBehaviour {
	float dotMaxScale = 0.215f;
	float dotMinScale = 0.0289f;

	WorldController world { get { return WorldController.Instance; } }

	public RectTransform JanDot;
	public RectTransform FebDot;
	public RectTransform MarDot;
	public RectTransform AprDot;
	public RectTransform MayDot;
	public RectTransform JunDot;
	public RectTransform JulDot;
	public RectTransform AugDot;
	public RectTransform SepDot;
	public RectTransform OctDot;
	public RectTransform NovDot;
	public RectTransform DecDot;


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

	public void SetDotSizes(){ //TODO: ANIMATE THE CIRCLES LATER.
		int numFireflies = 0;


		//january
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 0, world.getCloudyIndex());
		float scale = CalculateDotScale(numFireflies);
		JanDot.GetComponent<UniformScaleController>().SetScale(scale);

		//february
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 1, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		FebDot.GetComponent<UniformScaleController>().SetScale(scale);

		//march
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 2, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		MarDot.GetComponent<UniformScaleController>().SetScale(scale);

		//april
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 3, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		AprDot.GetComponent<UniformScaleController>().SetScale(scale);

		//may
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 4, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		MayDot.GetComponent<UniformScaleController>().SetScale(scale);

		//june
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 5, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		JunDot.GetComponent<UniformScaleController>().SetScale(scale);

		//july
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 6, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		JulDot.GetComponent<UniformScaleController>().SetScale(scale);

		//august
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 7, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		AugDot.GetComponent<UniformScaleController>().SetScale(scale);

		//september
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 8, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		SepDot.GetComponent<UniformScaleController>().SetScale(scale);

		//october
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 9, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		OctDot.GetComponent<UniformScaleController>().SetScale(scale);

		//november
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 10, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		NovDot.GetComponent<UniformScaleController>().SetScale(scale);

		//december
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 11, world.getCloudyIndex());
		scale = CalculateDotScale(numFireflies);
		DecDot.GetComponent<UniformScaleController>().SetScale(scale);
	}
}
