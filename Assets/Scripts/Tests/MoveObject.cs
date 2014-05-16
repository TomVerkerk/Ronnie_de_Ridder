using UnityEngine;
using System.Collections;

public class MoveObject : BaseTrackingHandler, ITrackableEventHandler
{
    public delegate void ObjectUpdater();

    public ObjectUpdater updater;
    protected override void OnTrackingFound()
    {
        if (updater != null)
            updater();

        base.OnTrackingFound();
        Renderer[] renderss = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer r in renderss)
        {
            r.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    protected override void OnTrackingLost()
    {
        if(updater!=null)
            updater();

        base.OnTrackingLost();
    }
}
