using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour {

	private RaycastHit selected;
	private bool start = true;
	private bool touched = false;
	private bool unselect = false;
	private bool retap = false;
	private bool UIon = false;
	private float screenPercX;
	private float screenPercY;
	public float objectMoveSpeed;
	public GUITexture arrowLeft;
	public GUITexture arrowRight;

	// Use this for initialization
	void Start () {
		screenPercX = Screen.width/100;
		screenPercY = Screen.height/100;
		arrowLeft.pixelInset = new Rect(0,0,Screen.width*0.2f,Screen.height);
		arrowRight.pixelInset = new Rect(Screen.width*0.8f,0,Screen.width*0.2f,Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount==1)
		{
			if(UIon == true)
			{
				Move();
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

	void Move()
	{
		foreach(var t in Input.touches)
		{
			if(touched == false)
			{
				if(t.position.x/screenPercX >= 80)
				{
					if(t.position.y/screenPercY >= 50)
					{
						selected.transform.Translate(Vector3.right * objectMoveSpeed * Time.deltaTime);
					}
					else
					{
						selected.transform.Translate(Vector3.back * objectMoveSpeed * Time.deltaTime);
					}
				}
				else if(t.position.x/screenPercX <= 20)
				{
					if(t.position.y/screenPercY >=50)
					{
						selected.transform.Translate(Vector3.left * objectMoveSpeed * Time.deltaTime);
					}
					else
					{
						selected.transform.Translate(Vector3.forward * objectMoveSpeed * Time.deltaTime);
					}
				}
				else
				{
					RaycastObject();
				}
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
				if(hit.transform.tag == "Moveable")
				{
					if(start == true)
					{
						hit.transform.gameObject.renderer.material.color = Color.yellow;
						ButtonsOn();
					}
					else if(hit.transform.gameObject.name != selected.transform.gameObject.name)
					{
						hit.transform.gameObject.renderer.material.color = Color.yellow;
						if(unselect == false && start == false)
						{
							selected.transform.gameObject.renderer.material.color = Color.white;
						}
						retap = false;
						ButtonsOn();
					}
					else if(unselect == false && retap == false)
					{
						hit.transform.gameObject.renderer.material.color = Color.white;
						ButtonsOff();
						retap = true;
					}
					else
					{
						hit.transform.gameObject.renderer.material.color = Color.yellow;
						retap = false;
						ButtonsOn();
					}
					unselect = false;
					selected = hit;
					start = false;
				}
				else
				{
					selected.transform.gameObject.renderer.material.color = Color.white;
					unselect = true;
					retap = false;
					ButtonsOff();
				}
			}
			else
			{
				selected.transform.gameObject.renderer.material.color = Color.white;
				unselect = true;
				retap = false;
				ButtonsOff();
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