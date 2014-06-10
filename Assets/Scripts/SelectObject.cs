using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour {

	public float minSwipePerc;
	private RaycastHit selected;
	private bool start = true;
	private bool touched = false;
	private bool unselect = false;
	private bool retap = false;
	private bool UIon = false;
	public float objectMoveSpeed;
	private Vector2 swipeBegin;
	private Vector2 swipeEnd;

	private Vector3 target;
	public bool arrived = true;
	public GameObject camera;
	public GameObject cube;

<<<<<<< HEAD
=======
	// Use this for initialization
	void Start () {
        Application.LoadLevelAdditive("UI-Cam");
		screenPercX = Screen.width/100;
		screenPercY = Screen.height/100;
		arrowLeft.pixelInset = new Rect(0,0,Screen.width*0.2f,Screen.height);
		arrowRight.pixelInset = new Rect(Screen.width*0.8f,0,Screen.width*0.2f,Screen.height);
	}
	
>>>>>>> ed678e45724f1dfabed3d8e1848b0c92a5a5b975
	// Update is called once per frame
	void Update () {
		if(arrived == false && start == false)
		{
			selected.transform.Translate(Vector3.forward * 30 * Time.deltaTime);
			if(Vector3.Distance(selected.transform.position,target) < 10)
			{
				arrived = true;
			}
		}
		else if(Input.touchCount==1)
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
		foreach(var T in Input.touches)
		{
			if(T.phase == TouchPhase.Began)
			{
				swipeBegin.x = ((100f/Screen.width)*T.position.x);
				swipeBegin.y = ((100f/Screen.height)*T.position.y);
			}
			else if(T.phase == TouchPhase.Ended)
			{
				swipeEnd.x = ((100f/Screen.width)*T.position.x);
				swipeEnd.y = ((100f/Screen.height)*T.position.y);
				if(swipeEnd.x - swipeBegin.x >= minSwipePerc || swipeBegin.x - swipeEnd.x <= -minSwipePerc || swipeEnd.y - swipeBegin.y >= minSwipePerc || swipeBegin.y - swipeEnd.y <= -minSwipePerc)
				{
					Vector3 screenPoint = new Vector3(swipeEnd.x,swipeEnd.y,0);
					Ray swipeRay = Camera.main.ScreenPointToRay(screenPoint);
					RaycastHit swipeHit;
					float swipeDis;
					if(Physics.Raycast(swipeRay,out swipeHit) && swipeHit.transform.tag == "Ground" && start == false)
				    {
						swipeDis = Vector3.Distance(camera.transform.position,cube.transform.position);
						target = swipeRay.GetPoint(swipeDis);
						selected.transform.LookAt(target);
						arrived = false;
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
						UIon = true;
					}
					else if(hit.transform.gameObject.name != selected.transform.gameObject.name)
					{
						hit.transform.gameObject.renderer.material.color = Color.yellow;
						if(unselect == false && start == false)
						{
							selected.transform.gameObject.renderer.material.color = Color.white;
						}
						retap = false;
						UIon = true;
					}
					else if(unselect == false && retap == false)
					{
						hit.transform.gameObject.renderer.material.color = Color.white;
						UIon = false;
						retap = true;
					}
					else
					{
						hit.transform.gameObject.renderer.material.color = Color.yellow;
						retap = false;
						UIon = true;
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
					UIon = false;
				}
			}
			else
			{
				selected.transform.gameObject.renderer.material.color = Color.white;
				unselect = true;
				retap = false;
				UIon = false;
			}
			touched = true;
		}
	}
}