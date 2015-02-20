using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	private float speed = 1;
	private Vector3 dir;
	private Vector3 leftDir = new Vector3(1,0,0);
	private Vector3 rightDir = new Vector3(-1,0,0);
	private bool left = false;

	// Update is called once per frame
	void Update () {
		if(transform.position.x>1){
			left = false;
		}
		if(transform.position.x<-1){
			left = true;
		}
		if(left){
			dir = transform.position + leftDir;
		}
		else{
			dir = transform.position + rightDir;
		}
		transform.position = Vector3.Lerp(transform.position,dir,speed);
	}
}
