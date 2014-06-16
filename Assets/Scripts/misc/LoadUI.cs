using UnityEngine;
using System.Collections;

public class LoadUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.LoadLevelAdditive("UI-Cam");
    }
}
