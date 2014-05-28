using UnityEngine;
using System.Collections;

public class BlinkingText : MonoBehaviour {

    Material m;
	void Start () {
        m = GetComponent<TextMesh>().renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
        m.color = new Color(1,1,1,Mathf.PingPong(Time.time / 2f, 0.8f)+0.2f);
	}
}
