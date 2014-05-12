using UnityEngine;
using System.Collections;

public class DebugRot : MonoBehaviour {

    public Transform toTrack;
	void Update () 
    {
        guiText.text = ("Rot: " + toTrack.rotation + "\nPos: " + toTrack.position);
	}
}
