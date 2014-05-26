using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour
{
    bool rooted = false;
    Quaternion orginalRot;
    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
=======
        transform.parent.gameObject.GetComponent<MoveObject>().updater += rotate;

        orginalRot = transform.rotation;
>>>>>>> b070dc314208887f3232e7d0cfa729ed47c43cdb
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
