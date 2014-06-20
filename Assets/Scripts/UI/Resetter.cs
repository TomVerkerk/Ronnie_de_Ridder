using UnityEngine;
using System.Collections;

public class Resetter : MonoBehaviour {

	public Vector3 resetPoint;

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Moveable")
		{
			col.transform.position = resetPoint;
			col.transform.gameObject.GetComponent<SelectObject>().arrived = true;
		}
	}
}
