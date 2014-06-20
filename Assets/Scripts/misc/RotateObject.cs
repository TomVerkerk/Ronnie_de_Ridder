using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	public SelectObject selectObject;
	public bool active = false;
	public bool delete;
	public float after;
	public float rotateStart;
	public float rotateSpeed;

	void Update(){
		if(active == true)
		{
			rotateStart = rotateStart * rotateSpeed;
			transform.Rotate(Vector3.forward * rotateStart * Time.deltaTime);
			if(delete == true)
			{
				selectObject.selected = new RaycastHit();
				selectObject.start = true;
				selectObject.touched = false;
				selectObject.unselect = false;
				selectObject.retap = false;
				selectObject.arrived = true;
				selectObject.select = false;
				Destroy(this.gameObject,after);
			}
		}
	}
}
