using UnityEngine;
using System.Collections;

public class ResumeGame :menu.TriggerV2 {

    Controles GameManager;
    bool UsedPause;
	void Start () {
	    object[] allObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) ;
        foreach (GameObject G in allObjects)
        {
            if (G.name == "ControleManager")
            {
                GameManager = G.GetComponent<Controles>();
            }
        }
        Disabled = true;
        renderer.material.color = Color.white;
	}

    void Update()
    {
        if (!UsedPause&&GameManager.GamePaused)
        {
            State = true;
            UsedPause = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.GamePaused = false;

       
    }
}
