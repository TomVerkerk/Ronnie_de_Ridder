using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour
{
    #region Vars
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.

    private AsyncOperation async = null; // When assigned, load is in progress.

    private Vector2 screenCenter;
    #endregion

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
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

    void OnGUI()
    {
        if (async != null)
        {
            GUI.DrawTexture(new Rect(screenCenter.x, screenCenter.y, 100, 50), emptyProgressBar);
            GUI.DrawTexture(new Rect(screenCenter.x, screenCenter.y, 100 * async.progress, 50), fullProgressBar);
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(screenCenter.x, screenCenter.y+50, 100, 50), string.Format("{0:N0}%", async.progress * 100f));
        }
    }
}