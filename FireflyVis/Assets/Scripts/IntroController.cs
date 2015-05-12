using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

	bool hasHitNextButton = false;


	public CanvasGroup pageOneGroup;
	//public CanvasGroup pageTwoGroup;
	//public CanvasGroup pageThreeGroup;
	//public CanvasGroup backgroundGroup;

	public IntroState currentIntroState; 

	public enum IntroState{
		pageOne,
		//pageTwo,
		//pageThree,
		finished
	}

	// Use this for initialization
	void Start () {
		Init ();
		//StartCoroutine(RunIntroduction());
	}

	void Init(){
		//backgroundGroup.alpha = 1.0f;
		pageOneGroup.alpha = 1.0f;
		//pageTwoGroup.alpha = 0.0f;
		//pageThreeGroup.alpha = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		GetInput ();
		if(hasHitNextButton){
			StartCoroutine(FadeOutNextState());
			hasHitNextButton = false;
		}
	}

	void GetInput(){
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			hasHitNextButton = true;
		}
	}

	IEnumerator RunIntroduction(){

		while(currentIntroState != IntroState.finished){
			yield return new WaitForSeconds(3.0f);
			yield return StartCoroutine(FadeOutNextState());
		}

		yield return 0;

	}

	IEnumerator FadeOutNextState(){

		//float time = 0.0f;
		//float timeToFade = 1.0f;
		float fadeAmount = 0.01f;
		float fadeOutAlphaEpsilon = 0.01f;

		CanvasGroup groupToFadeOut = null;
		CanvasGroup groupToFadeIn = null;
		if(currentIntroState == IntroState.pageOne){
			groupToFadeOut = pageOneGroup;
			//groupToFadeIn = pageTwoGroup;
		}
		/*else if(currentIntroState == IntroState.pageTwo){
			groupToFadeOut = pageTwoGroup;
			groupToFadeIn = pageThreeGroup;
		}
		else if(currentIntroState == IntroState.pageThree){
			groupToFadeOut = pageThreeGroup;
		}*/

		if(groupToFadeOut != null){
			Debug.Log("fading out");
			while( groupToFadeOut.alpha > fadeOutAlphaEpsilon){
				groupToFadeOut.alpha -= fadeAmount;
				//fade out background
//				if(currentIntroState == IntroState.pageThree){
				//	backgroundGroup.alpha -= fadeAmount;
				//}
				yield return 0;
			}
			groupToFadeOut.alpha = 0.0f;
			//fade out background
			/*if(currentIntroState == IntroState.pageOne){
				backgroundGroup.alpha = 0.0f;
			}*/
		}
		if(groupToFadeIn != null){
			Debug.Log("fading in");
			while( groupToFadeIn.alpha < 1.0f){
				groupToFadeIn.alpha += fadeAmount;
				yield return 0;
			}
			groupToFadeIn.alpha = 1.0f;
		}



		//change state!
		if(currentIntroState == IntroState.pageOne){
			currentIntroState = IntroState.finished;
			Debug.Log("finished!");
			pageOneGroup.gameObject.SetActive(false);

			//START PLAYING ONCE THE INTRO SCREEN IS FINISHED
			WorldController.Instance.myDateTime.isPlaying = true;
		}
		/*(else if(currentIntroState == IntroState.pageTwo){
			currentIntroState = IntroState.pageThree;
			Debug.Log("page two!");
		}
		else if(currentIntroState == IntroState.pageThree){
			currentIntroState = IntroState.finished;
			Debug.Log("finished!");
			pageOneGroup.gameObject.SetActive(false);
			//pageTwoGroup.gameObject.SetActive(false);
			//pageThreeGroup.gameObject.SetActive(false);
			//backgroundGroup.gameObject.SetActive(false);
		}*/

		yield return 0;
	}
}
