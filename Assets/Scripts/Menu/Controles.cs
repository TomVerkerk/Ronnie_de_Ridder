using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
            Destroy(this.gameObject);
        }
	}
}
