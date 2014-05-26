using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0)
		{
			transform.Translate(Vector3.back*speed*Time.deltaTime);
		}
	}
}
