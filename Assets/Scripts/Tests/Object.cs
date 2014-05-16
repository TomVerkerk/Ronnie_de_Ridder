using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {
    bool rooted = false;
    Quaternion orginalRot;
	// Use this for initialization
	void Start () {
        transform.parent.gameObject.GetComponent<MoveObject>().updater+=rotate;

        orginalRot = transform.rotation;
	}

    void rotate()
    {
        rooted = !rooted;

        if (rooted)
        {
            transform.Rotate(20, 40, 0);
        }
        else
        {
            transform.rotation = orginalRot;
        }
    }

}
