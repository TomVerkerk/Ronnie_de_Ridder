using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	public bool active = false;
	public bool delete;
	public float after;
	public float rotateStart;
	public float rotateSpeed;

	void Update(){
		if(active == true)
		{
			rotateStart = rotateStart * rotateSpeed;
			transform.Rotate(Vector3.left * rotateStart * Time.deltaTime);
			if(delete == true)
			{
				Destroy(this.gameObject,after);
			}
		}
	}
}
