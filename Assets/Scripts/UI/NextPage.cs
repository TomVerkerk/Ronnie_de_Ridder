using UnityEngine;
using System.Collections;

public class NextPage : MonoBehaviour {

	public GUITexture nextPage;
	public GUITexture lookAt;
	public GUITexture theEnd;
	public Animator animatorPage1;
	public Animator animatorPage2;
	private bool UiOn = false;
	private bool shown = false;
	private float timer=0;
	private float endTimer=0;

	void Start(){
		nextPage.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		lookAt.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		theEnd.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		lookAt.enabled = true;
		theEnd.enabled = false;
		nextPage.enabled = false;
	}

	void Update () {
		if(animatorPage1.enabled == true)
		{
			lookAt.enabled = false;
			timer++;
			if(timer >= 800 && UiOn == false)
			{
				nextPage.enabled = true;
				UiOn = true;
			}
		}
		if(animatorPage2.enabled == true)
		{
			nextPage.enabled = false;
			endTimer++;
			if(endTimer >= 1300)
			{
				lookAt.enabled = false;
				theEnd.enabled = true;
			}
		}
	}
}
