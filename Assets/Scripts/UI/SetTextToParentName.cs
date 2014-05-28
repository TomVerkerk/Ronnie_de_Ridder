using UnityEngine;
using System.Collections;

public class SetTextToParentName : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = transform.parent.name;
        Destroy(this);
	}
}
