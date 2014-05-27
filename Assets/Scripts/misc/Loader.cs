using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour
{
    #region Vars
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.

    private AsyncOperation async = null; // When assigned, load is in progress.

    private Vector2 screenCenter;
    private Vector2 screenSize;
    [Range(0f, 1f)]
    public float posX;
    [Range(0f, 1f)]
    public float posY;

    private Vector2 pos;

    
    #endregion

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        screenSize = new Vector2(Screen.width,Screen.height);
        pos = new Vector2(Screen.width*posX, Screen.height*posY);
    }

    public void SyncLoadLevel(string levelName)
    {
        async = Application.LoadLevelAsync(levelName);
        Load();
    }

    IEnumerator Load()
    {
        yield return async;
    }

    void Update()
    {

    }

    void OnGUI()
    {

        if (async != null)
        {
            //GUI.DrawTexture(new Rect(screenCenter.x, screenCenter.y, 100, 50), emptyProgressBar);
            // GUI.DrawTexture(new Rect(screenCenter.x, screenCenter.y, 100 * async.progress, 50), fullProgressBar);
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            GUI.DrawTexture(new Rect(pos.x, pos.y, screenSize.x-(pos.x*2f), 50), emptyProgressBar);
            GUI.DrawTexture(new Rect(pos.x, pos.y, (screenSize.x - (pos.x * 2f)) * async.progress, 50), fullProgressBar);
            //async.progress
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 32;
            GUI.Label(new Rect(screenCenter.x, screenSize.y - 100 + 50, 100, 50), string.Format("{0:N0}%", async.progress * 100f));

        }
        else
        {
            GUI.skin.label.alignment = TextAnchor.UpperLeft;

            Debug.Log(new Rect((screenSize.x * 1f) + pos.x, pos.y, screenSize.x - 6f * 1f, 50));
            Debug.Log("ScreenSize: " + screenSize + " ScreenCenter : " + screenCenter);
            GUI.TextArea(new Rect(pos.x, pos.y, screenSize.x * (Time.time / 100f), 50), "Test");
        }
    }
}