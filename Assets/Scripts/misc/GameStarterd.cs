using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Loader))]
public class GameStarterd : MonoBehaviour {

    public string load;

    void Start()
    {
        GetComponent<Loader>().SyncLoadLevel(load);
    }
}
