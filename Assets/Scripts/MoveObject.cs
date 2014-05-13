using UnityEngine;
using System.Collections;

public class MoveObject : BaseTrackingHandler, ITrackableEventHandler
{

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Renderer[] renderss = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer r in renderss)
        {
            r.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
