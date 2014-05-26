using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour {

	private RaycastHit selected;
	private bool start = true;
	private bool touched = false;
	private bool unselect = false;
	private bool retap = false;
	private bool UIon = false;
	private float screenPerc;
	public GUITexture arrowLeft;
	public GUITexture arrowRight;

	// Use this for initialization
	void Start () {
		screenPerc = 100/Screen.width;
		arrowLeft.pixelInset = new Rect(0,0,Screen.width*0.2f,Screen.height);
		arrowRight.pixelInset = new Rect(Screen.width*0.8f,0,Screen.width*0.2f,Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount==1)
		{
			if(UIon == true)
			{
				ObjectMove();
			}
			else
			{
				RaycastObject();
			}
		}
		else
		{
			touched = false;
		}

	}

	void ObjectMove()
	{
		if(touched == false)
		{
			if(screenPerc * Input.touches[1].position.x >= 80)
			{
				selected.transform.Translate(new Vector3(100,0,0));
			}
			else if(screenPerc * Input.touches[1].position.x <= 20)
			{
				selected.transform.Translate(new Vector3(-100,0,0));
			}
			else
			{
				RaycastObject();
			}
		}
	}

	void RaycastObject()
	{
		if(touched == false)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit))
			{
				if(start == true)
				{
					ButtonsOn();
					hit.transform.GetComponent<ObjectInterface>().renderer.material.color = Color.yellow;
				}
				else if(hit.transform.gameObject.name != selected.transform.gameObject.name)
				{
					ButtonsOn();
					hit.transform.GetComponent<ObjectInterface>().renderer.material.color = Color.yellow;
					if(unselect == false && start == false)
					{
						selected.transform.GetComponent<ObjectInterface>().renderer.material.color = Color.white;
					}
				}
				else if(unselect == false && retap == false)
				{
					hit.transform.GetComponent<ObjectInterface>().renderer.material.color = Color.white;
					ButtonsOff();
					retap = true;
				}
				else
				{
					ButtonsOn();
					hit.transform.GetComponent<ObjectInterface>().renderer.material.color = Color.yellow;
					retap = false;
				}
				unselect = false;
				selected = hit;
				start = false;
			}
			else
			{
				ButtonsOff();
				selected.transform.GetComponent<ObjectInterface>().renderer.material.color = Color.white;
				unselect = true;
				retap = false;
			}
			touched = true;
		}
	}

	void ButtonsOn()
	{
		arrowLeft.enabled=true;
		arrowRight.enabled=true;
		UIon = true;
	}

	void ButtonsOff()
	{
		arrowLeft.enabled=false;
		arrowRight.enabled=false;
		UIon = false;
	}
}