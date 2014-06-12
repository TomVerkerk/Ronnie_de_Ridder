using UnityEngine;
using System.Collections;

public class Resetter : MonoBehaviour {

	public Vector3 resetPoint;

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Moveable")
		{
			col.transform.position = resetPoint;
		}
	}
}
