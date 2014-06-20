using UnityEngine;
using System.Collections;

public class MoveInfo : MonoBehaviour {

	public Vector3 constrainAxis;
	public float startScriptAt;
	public bool rotate;
	public RotateObject rotateObject;
	public SelectObject selectObject;

	void Update(){
		if(transform.position.y >= startScriptAt && rotate == true)
		{
			rotateObject.active = true;
			selectObject.arrived = true;
		}
	}
}
