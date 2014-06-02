using UnityEngine;
using System.Collections;

public class ResumeGame :menu.TriggerV2 {

    Controles GameManager;
    bool UsedPause;
	protected override void Start () {
	    object[] allObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) ;
        foreach (GameObject G in allObjects)
        {
            if (G.name == "ControleManager")
            {
                GameManager = G.GetComponent<Controles>();
            }
        }
        GameManager.GamePaused = false;
	}
    void Update()
    {
        if (!UsedPause && GameManager.GamePaused)
        {
            State = true;
            UsedPause = true;
            OpenMenuID = 1;
        }
        else
        {
            OpenMenuID = 0;
        }
    }

    protected override void IWillDo()
    {
        GameManager.GamePaused = false;
        UsedPause = false;
        State = true;
    }
}
