using UnityEngine;
using System.Collections;

public class TimelineVisController : MonoBehaviour {

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

	public void SetDotSizes(){ //TODO: ANIMATE THE CIRCLES LATER.
		int numFireflies = 0;


		//january
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 0, world.getCloudyIndex());
		JanDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//february
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 1, world.getCloudyIndex());
		FebDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//march
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 2, world.getCloudyIndex());
		MarDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);;

		//april
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 3, world.getCloudyIndex());
		AprDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//may
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 4, world.getCloudyIndex());
		MayDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//june
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 5, world.getCloudyIndex());
		JunDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//july
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 6, world.getCloudyIndex());
		JulDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//august
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 7, world.getCloudyIndex());
		AugDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//september
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 8, world.getCloudyIndex());
		SepDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//october
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 9, world.getCloudyIndex());
		OctDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//november
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 10, world.getCloudyIndex());
		NovDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);

		//december
		numFireflies = world.myCharacter.currentState.GetAvgNumFirefliesMONTH(world.myDateTime.currentYear, 11, world.getCloudyIndex());
		DecDot.GetComponent<UniformScaleController>().SetScaleBasedOnFireflies(numFireflies);
	}
}
